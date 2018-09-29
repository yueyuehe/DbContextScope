
using HWAdmin.Entity.Base;
using System;
using System.Collections.Generic;

namespace HWAdmin.Entity.System
{

    public partial class PageElement : BaseEntity
    {
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }


        /// <summary>
        ///  Ȩ�ޱ� 1-1
        /// </summary>
        public Authority Authority { get; set; }
    }
}
