using qqliwuwang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace qqliwuwang.Helper
{
    public class CommonHelper
    {
        /// <summary>
        /// 获取当前线程中的用户
        /// </summary>
        /// <returns></returns>
        public static Account LoginUser()
        {
            var user = CallContext.LogicalGetData("Login_User") as Account;
            if (user == null)
            {
                return new Account();
            }
            return user;
        }
    }
}