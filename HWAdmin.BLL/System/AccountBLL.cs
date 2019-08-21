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
using HWAdmin.IDAL.System;

namespace HWAdmin.BLL.System
{
    /// <summary>
    /// 账号业务类
    /// </summary>
    public class AccountBLL : SysBaseBLL<Account>, IAccountBLL
    {
        public AccountBLL(IAccountDAL dal) : base(dal)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        public void AccountConfirmByEmail(string code)
        {
            return;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Account Find(string username, string password)
        {
            return BasicDal.FindOne(p => p.AccountName == username && p.Password == password && p.DeleteFlg == DeleteFlg.N);
        }
    }
}
