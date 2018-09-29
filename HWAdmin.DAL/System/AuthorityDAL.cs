using HWAdmin.DAL.Context;
using HWAdmin.Entity.System;
using HWAdmin.IDAL.System;
using Mehdime.Entity.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.DAL.System
{
    /// <summary>
    /// 权限的集合
    /// </summary>
    public class AuthorityDAL : BasicDAL<Authority, SysContext>, IAuthorityDAL
    {
    }
}
