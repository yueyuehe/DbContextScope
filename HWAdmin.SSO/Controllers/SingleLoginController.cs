using HWAdmin.BLL.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWAdmin.SSO.Controllers
{
    public class SingleLoginController : Controller
    {
        AccountBLL accountBll = new AccountBLL();

        /// <summary>
        /// 转到登录界面
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginUI(string callback)
        {
            ViewData["calback"] = callback ?? "";
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="callback">操作成功后返回的地址</param>
        /// <returns></returns>
        public ActionResult Login(string callback)
        {
            //获取用户名和密码
            var username = Request["username"];
            var password = Request["password"];
            //查用户
            var model = accountBll.Login(username, password);
            if (model == null)
            {
                ViewData["Msg"] = "用户名或密码错误!";
                ViewData["callback"] = callback;
                return View("LoginUI");
            }
            //创建session
            var token = Guid.NewGuid().ToString();
            Session.Add("token", model);
            HttpCookie cookie = new HttpCookie(token);
            cookie.Domain = "HWAdmin.com";
            cookie.Value = token;
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
            Response.Redirect(callback);
            return View();
        }

        /// <summary>
        /// 登出后返回的地址
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public ActionResult Logout(string callback)
        {


            return View();
        }
    }
}