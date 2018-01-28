
using System;
using System.Collections.Generic;
namespace Authority.Entity
{
    public partial class Group
    {
        public Group()
        {
            this.User = new HashSet<User>();
            this.Role = new HashSet<Role>();
            this.Childs = new HashSet<Group>();
        }

        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用户集合
        /// </summary>
        public virtual ICollection<User> User { get; set; }
        /// <summary>
        /// 权限集合
        /// </summary>
        public virtual ICollection<Role> Role { get; set; }
        /// <summary>
        /// 子组集合
        /// </summary>
        public virtual ICollection<Group> Childs { get; set; }
        /// <summary>
        /// 父组
        /// </summary>
        public virtual Group Parent { get; set; }


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
