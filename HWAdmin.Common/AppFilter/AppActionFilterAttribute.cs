using HWAdmin.Common.Config;
using HWAdmin.Common.Config.AppStr;
using HWAdmin.Common.Enums;
using HWAdmin.Common.Helpers;
using HWAdmin.Common.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.AppFilter
* 项目描述 ：
* 类 名 称 ：AppActionFilterAttribute
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.AppFilter
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/5/26 22:40:35
* 更新时间 ：2018/5/26 22:40:35
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.AppFilter
{
    public class AppActionFilterAttribute : ActionFilterAttribute
    {
        public List<RequestMethod> MethodList { get; set; }

        public AppActionFilterAttribute()
        {
            ///默认只开启get和post
            MethodList = new List<RequestMethod>
            {
                RequestMethod.GET,
                RequestMethod.POST
            };
        }

        public AppActionFilterAttribute(params RequestMethod[] types)
        {
            MethodList = new List<RequestMethod>();
            foreach (var item in types)
            {
                MethodList.Add(item);
            }
        }

        /// <summary>
        /// 在执行操作方法后由 ASP.NET MVC 框架调用。
        /// </summary>
        /// <param name="filterContext">筛选器上下文。</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            #region 验证是否需要记录日志 版本1 弃用

            /*
            //获取config配置文件中 是否开启操作日志记录
            var isOpenLog = ConfigurationManager.AppSettings.Get(ConfigParam.ActionLog_Open_Flag);
            //没有开启 跳过记录日志
            if (isOpenLog == null || isOpenLog.ToLower() != "true") return;
            //判断请求的方法 GET POST PUT DELETE
            var allowStr = ConfigurationManager.AppSettings.Get(ConfigParam.ActionLog_Open_Allow_Method);
            //默认不开启 没有配置不开启
            if (string.IsNullOrEmpty(allowStr)) return;
            var allowArr = allowStr.Split(new string[] { ",", "|" }, StringSplitOptions.RemoveEmptyEntries);
            var requestMethod = filterContext.HttpContext.Request.RequestType;
            var allowToLog = false;
            ///遍历 判断请求方法是否开启了日志记录
            foreach (var item in allowArr)
            {
                if (item.ToUpper() == requestMethod)
                {
                    allowToLog = true;
                    break;
                }
            }
            //没有开启则返回 不做日志记录
            if (!allowToLog) return;
            */
            #endregion

            #region 验证是否需要记录日志
            //获取请求类型字符串
            var requestMethod = filterContext.HttpContext.Request.RequestType;
            //转为枚举
            var methodType = (RequestMethod)Enum.Parse(typeof(RequestMethod), requestMethod);
            //判断请求类型是否在 列表中 不在 返回
            if (!MethodList.Contains(methodType)) return;
            #endregion

            #region 记录日志

            //执行后  记录日志
            //1:初始化 信息对象
            LogEventInfo eventInfo = new LogEventInfo();
            eventInfo.Level = LogLevel.Info;
            var desAttr = filterContext.ActionDescriptor.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (desAttr == null || desAttr.Length == 0)
            {
                eventInfo.Properties["Operation"] = "未声明Action方法，请添加 System.EnterpriseServices.DescriptionAttribute 特性";
            }
            else
            {
                eventInfo.Properties["Operation"] = ((DescriptionAttribute)desAttr.First()).Description;
            }

            var form = filterContext.HttpContext.Request.Form;
            var dic = new Dictionary<string, string>();
            foreach (string item in form.Keys)
            {
                dic.Add(item, form[item]);
            }
            eventInfo.Properties["FormParams"] = JsonHelper.Instance.Serialize(dic);
            //2判断是否执行出错

            //2.1有错误
            if (filterContext.Exception != null)
            {
                eventInfo.Properties["ExecuteStatus"] = ExecuteStatus.Failed;
                eventInfo.Properties["ErrorMsg"] = filterContext.Exception.Message;
            }
            else//2.2 没有错误
            {
                //判断result是否是jsonresult
                if (filterContext.Result.GetType().IsAssignableFrom(typeof(JsonResult)))
                {
                    var result = filterContext.Result as JsonResult;
                    if (result.Data is IResponse response)
                    {
                        eventInfo.Properties["ExecuteStatus"] = response.Status ? ExecuteStatus.Success : ExecuteStatus.Failed;
                        eventInfo.Properties["ErrorMsg"] = response.Message;
                    }
                    else
                    {
                        eventInfo.Properties["ExecuteStatus"] = ExecuteStatus.Unknown;
                        eventInfo.Properties["ErrorMsg"] = "JsonResult.Data 未继承IResponse，不能判断是否执行成功!";
                    }
                }
                else
                {//不是 执行成功
                    eventInfo.Properties["ExecuteStatus"] = ExecuteStatus.Success;
                    eventInfo.Properties["ErrorMsg"] = "默认";
                }
            }
            NLogHelper.Info(eventInfo);
            #endregion

        }
    }
}
