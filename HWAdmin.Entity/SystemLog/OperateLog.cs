using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.Entity.SystemLog
{
    /// <summary>
    /// 操作日志(保存到数据库)
    /// </summary>
    public class OperateLog
    {
        public string Id { get; set; }

        /// <summary>
        /// 用户ID 没有登录的话 为IP+system
        /// </summary>
        public string AccountID { get; set; }

        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public string Parameter { get; set; }

        /// <summary>
        /// 执行状态 成功 或失败
        /// </summary>
        public string Status { get; set; }
    }
}
