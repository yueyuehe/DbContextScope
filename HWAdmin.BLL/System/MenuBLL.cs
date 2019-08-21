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
using HWAdmin.IDAL.System;

namespace HWAdmin.BLL.System
{
    /// <summary>
    /// 菜单信息业务类
    /// </summary>
    public class MenuBLL : SysBaseBLL<Menu>, IMenuBLL
    {
        public MenuBLL(IMenuDAL dal):base(dal)
        {
        }
    }
}
