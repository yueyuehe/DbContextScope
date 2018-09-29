using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity.Extension;
using HWAdmin.Entity.System;

namespace HWAdmin.IBLL.System
{
    /// <summary>
    /// 账号业务类
    /// </summary>
    public interface IAccountBLL : IBasicBLL<Account>
    {

        /// <summary>
        /// 登录 获取账号
        /// </summary>
        /// <param name="username"></param>
        /// <param name="parssword"></param>
        /// <returns></returns>
        Account Login(string username, string parssword);

    }
}
