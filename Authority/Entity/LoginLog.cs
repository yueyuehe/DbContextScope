using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Basic
{
    /// <summary>
    /// 登录日志(保存到数据库)
    /// </summary>
    public class LoginLog
    {
        public string Id { get; set; }

        /// <summary>
        /// 进行登录的用户名  记录判断是否有撞库行为 或试验密码行为
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string LoginPassword { get; set; }

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
