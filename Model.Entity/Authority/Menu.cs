using System;
using System.Collections.Generic;

namespace Model.Entity.Authority
{
    public partial class Menu
    {
        public Menu()
        {
            this.Authority = new HashSet<Authority>();
            this.Childs = new HashSet<Menu>();
        }
        public int Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public virtual ICollection<Authority> Authority { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual ICollection<Menu> Childs { get; set; }

        /// <summary>
        /// 父菜单
        /// </summary>
        public virtual Menu Parent { get; set; }


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
