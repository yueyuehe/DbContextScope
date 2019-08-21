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
        /// 根据用户名和密码查找
        /// </summary>
        /// <param name="username"></param>
        /// <param name="parssword"></param>
        /// <returns></returns>
        Account Find(string username, string parssword);

        /// <summary>
        /// 账号确认
        /// </summary>
        /// <param name="code"></param>
        void AccountConfirmByEmail(string code);

    }
}
