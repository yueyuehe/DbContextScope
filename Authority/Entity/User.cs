using System;
using System.Collections.Generic;

namespace Authority.Entity
{
    public partial class User
    {
        public User()
        {
            this.Group = new HashSet<Group>();
            this.Role = new HashSet<Role>();
        }

        public int Id { get; set; }
        /// <summary>
        /// 登录名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        public virtual ICollection<Group> Group { get; set; }
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
