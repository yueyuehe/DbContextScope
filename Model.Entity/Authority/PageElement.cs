
using System;
using System.Collections.Generic;

namespace Model.Entity.Authority
{

    public partial class PageElement
    {
        public PageElement()
        {
            this.Authority = new HashSet<Authority>();
        }

        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 权限集合
        /// </summary>
        public virtual ICollection<Authority> Authority { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 新增人
        /// </summary>
        public virtual User CreateUser { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public virtual User UpdateUser { get; set; }
    }
}
