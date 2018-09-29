using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity.Extension;
using HWAdmin.BLL.Base;
using HWAdmin.Entity.System;
using HWAdmin.IBLL.System;
using HWAdmin.DAL.System;

namespace HWAdmin.BLL.System
{
    /// <summary>
    /// 权限业务类
    /// </summary>
    public class AuthorityBLL : SysBaseBLL<Authority>, IAuthorityBLL
    {
        public AuthorityBLL()
        {
            basicDal = new AuthorityDAL();
        }

    }
}
