using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity.Extension;
using HWAdmin.BLL.Base;
using HWAdmin.Entity.System;
using HWAdmin.IBLL.System;
using HWAdmin.IDAL.System;

namespace HWAdmin.BLL.System
{
    /// <summary>
    /// 角色类
    /// </summary>
    public class RoleBLL : SysBaseBLL<Role>, IRoleBLL
    {
        public RoleBLL(IRoleDAL dal) : base(dal)
        {

        }

    }
}
