using System;
using System.Collections.Generic;

namespace Model.Entity.Authority
{
   
    
    public partial class Authority
    {
        public Authority()
        {
            this.Menu = new HashSet<Menu>();
            this.FileInfo = new HashSet<FileInfo>();
            this.PageElement = new HashSet<PageElement>();
            this.Action = new HashSet<Action>();
            this.Role = new HashSet<Role>();
        }
    
        public int Id { get; set; }
    

        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<FileInfo> FileInfo { get; set; }
        public virtual ICollection<PageElement> PageElement { get; set; }
        public virtual ICollection<Action> Action { get; set; }
        public virtual ICollection<Role> Role { get; set; }

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
