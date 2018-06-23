using Common.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Common.AppFilter
* 项目描述 ：
* 类 名 称 ：AppErrorAttribute
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：Common.Filter
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/5/23 22:46:38
* 更新时间 ：2018/5/23 22:46:38
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace Common.AppFilter
{
    public class AppHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 在发生异常时调用。
        /// </summary>
        /// <param name="filterContext"> 操作筛选器上下文。</param>
        public override void OnException(ExceptionContext filterContext)
        {
            //记录日志
            var form = filterContext.RequestContext.HttpContext.Request.Form;
            foreach (string item in form.Keys)
            {
                filterContext.Exception.Data.Add(item, form[item]);
            }
            NLogHelper.Error(filterContext.Exception);

            //页面跳转 还是json数据回写
            //开发状态 debug状态下
            var status = true;
            if (status)
            {
                //基类处理
                base.OnException(filterContext);
                return;
            }
            //生产状态下
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                //返回错误数据
                var result = new { Status = false, Message = filterContext.Exception.Message };
                var jsonResult = new JsonResult();
                jsonResult.Data = result;
                filterContext.Result = jsonResult;
                return;
            }
            else
            {
                //转到错误页面

            }
        }
    }
}
