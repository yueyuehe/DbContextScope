using HWAdmin.BLL.Base;
using HWAdmin.DAL.System;
using HWAdmin.Entity.System;
using HWAdmin.IBLL.System;
using HWAdmin.IDAL.System;
using Mehdime.Entity.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.BLL.System
{
    /// <summary>
    /// 文件信息业务
    /// </summary>
    public class FileAuthBLL : SysBaseBLL<FileAuth>, IFileAuthBLL
    {
        public FileAuthBLL(IFileAuthDAL dal) : base(dal)
        {

        }
    }
}
