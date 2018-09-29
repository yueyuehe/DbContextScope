using HWAdmin.BLL.Base;
using HWAdmin.DAL.System;
using HWAdmin.Entity.System;
using HWAdmin.IBLL.System;
using Mehdime.Entity.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.BLL.System
{
    /// <summary>
    /// action业务类
    /// </summary>
    public class ActionAuthBLL : SysBaseBLL<ActionAuth>, IActionAuthBLL
    {
        public ActionAuthBLL()
        {
            basicDal = new ActionAuthDAL();
        }
    }
}
