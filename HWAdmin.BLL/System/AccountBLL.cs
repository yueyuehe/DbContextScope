using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity.Extension;
using HWAdmin.Entity.System;
using HWAdmin.BLL.Base;
using HWAdmin.IBLL.System;
using HWAdmin.DAL.System;
using HWAdmin.Entity.Enum;

namespace HWAdmin.BLL.System
{
    /// <summary>
    /// 账号业务类
    /// </summary>
    public class AccountBLL : SysBaseBLL<Account>, IAccountBLL
    {
        public AccountBLL()
        {
            basicDal = new AccountDAL();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Account Login(string username, string password)
        {
            return basicDal.FindOne(p => p.AccountName == username && p.Password == password && p.DeleteFlg == DeleteFlg.N);
        }
    }
}
