using System;
using System.Collections.Generic;

namespace Authority.Basic
{
    /// <summary>
    /// 操作权限 功能权限
    /// </summary>
    public partial class Action : BaseEntity
    {

        /// <summary>
        /// 名称
        /// </summary>d 0
        public string Name { get; set; }
        /// <summary>
        /// 请求URL
        /// </summary>
        public string Url { get; set; }


    }
}
