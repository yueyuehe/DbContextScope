using HWAdmin.Entity.Base;
using System;
using System.Collections.Generic;

namespace HWAdmin.Entity.System
{
    /// <summary>
    /// 操作权限 功能权限
    /// </summary>
    public partial class ActionAuth : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>d 0
        public string Name { get; set; }
        /// <summary>
        /// 请求URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///  权限表 1-1
        /// </summary>
        public Authority Authority { get; set; }

    }
}
