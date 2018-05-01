using System;
using System.Collections.Generic;

namespace Authority.Entity
{
    public partial class Menu : BaseEntity
    {
        public Menu()
        {
            this.Childs = new HashSet<Menu>();
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单URL
        /// </summary>
        public string Url { get; set; }
       
        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual ICollection<Menu> Childs { get; set; }

        /// <summary>
        /// 父菜单
        /// </summary>
        public virtual Menu Parent { get; set; }

    }
}
