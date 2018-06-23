using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Basic
{
    /// <summary>
    /// 错误日志 (保存到文件) 或警告 或 程序崩溃日志
    /// </summary>
    public class ErrorLog
    {

        public string Id { get; set; }

        /// <summary>
        /// 用户ID 没有登录的话 为IP+system
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// 简单信息
        /// </summary>
        public string SimpleMessage { get; set; }
        public DateTime Time { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public string Parameter { get; set; }
        /// <summary>
        /// 详细信息
        /// </summary>
        public string DetailedInformation { get; set; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public string Level { get; set; }

    }
}
