
using System;
using System.Collections.Generic;

namespace Authority.Entity
{

    public partial class Role : BaseEntity
    {
        public Role()
        {
            this.Accounts = new HashSet<Account>();
            this.Groups = new HashSet<Group>();
            this.Authorities = new HashSet<Authority>();
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户集合
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }

        /// <summary>
        /// 组集合
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// 权限集合
        /// </summary>
        public virtual ICollection<Authority> Authorities { get; set; }

    }
}
