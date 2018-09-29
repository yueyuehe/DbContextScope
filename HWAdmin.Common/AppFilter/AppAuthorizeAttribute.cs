using HWAdmin.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.AppFilter
* 项目描述 ：
* 类 名 称 ：AppAuthorizeAttribute
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.AppFilter
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/5/26 22:45:02
* 更新时间 ：2018/5/26 22:45:02
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.AppFilter
{
    public class AppAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authority = httpContext.Session[Config.ConfigParam.Authority_All_Session] as AuthorityModel;
            if (authority == null)
            {
                return false;//表示没有登录
            }
            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);
        }
    }
}
