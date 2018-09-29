
using HWAdmin.Entity.Base;
using System;
using System.Collections.Generic;

namespace HWAdmin.Entity.System
{

    public partial class PageElement : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }


        /// <summary>
        ///  权限表 1-1
        /// </summary>
        public Authority Authority { get; set; }
    }
}
