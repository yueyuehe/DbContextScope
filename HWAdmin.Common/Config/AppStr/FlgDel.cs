using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.Common.Config.AppStr
{
    /// <summary>
    /// 标记是否删除
    /// </summary>
    public class FlgDel
    {
        public const string N = "0";
        public const string Y = "1";
    }

    /// <summary>
    /// 执行状态
    /// </summary>
    public class ExecuteStatus
    {
        public const string Failed = "1";
        public const string Success = "0";
        public const string Unknown = "2";
    }

}
