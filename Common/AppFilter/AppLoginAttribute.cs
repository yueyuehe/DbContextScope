using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Common.AppFilter
* 项目描述 ：
* 类 名 称 ：AppLoginAttribute
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：Common.AppFilter
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/7 22:31:09
* 更新时间 ：2018/6/7 22:31:09
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace Common.AppFilter
{
    /// <summary>
    /// 登录验证 使用Identity的登录验证方式
    /// </summary>
    public class AppLoginAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var result = base.AuthorizeCore(httpContext);
            //如果验证成功，表示已经登录
            if (result)
            {
                //从数据库查询获取 权限放入session 中
                AuthorityModel authority = new AuthorityModel();
                httpContext.Session[Config.ConfigParam.Authority_All_Session] = authority;
            }
            return result;
        }
    }
}
