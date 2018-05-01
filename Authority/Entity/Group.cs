
using System;
using System.Collections.Generic;
namespace Authority.Entity
{
    public partial class Group : BaseEntity
    {
        public Group()
        {
            this.Accounts = new HashSet<Account>();
            this.Roles = new HashSet<Role>();
            this.Childs = new HashSet<Group>();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户集合
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }
        /// <summary>
        /// 权限集合
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
        /// <summary>
        /// 子组集合
        /// </summary>
        public virtual ICollection<Group> Childs { get; set; }
        /// <summary>
        /// 父组
        /// </summary>
        public virtual Group Parent { get; set; }


    }
}
