
using System;
using System.Collections.Generic;

namespace Model.Entity.Authority
{

    public partial class Role
    {
        public Role()
        {
            this.User = new HashSet<User>();
            this.Group = new HashSet<Group>();
            this.Authority = new HashSet<Authority>();
        }

        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用户集合
        /// </summary>
        public virtual ICollection<User> User { get; set; }
        /// <summary>
        /// 组集合
        /// </summary>
        public virtual ICollection<Group> Group { get; set; }
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
