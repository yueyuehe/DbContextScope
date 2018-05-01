using System;
using System.Collections.Generic;

namespace Authority.Entity
{

    /// <summary>
    /// 权限的集合表  菜单，功能等权限是1-1关系
    /// </summary>
    public partial class Authority : BaseEntity
    {
        public Authority()
        {

            this.Roles = new HashSet<Role>();
            this.Accounts = new HashSet<Account>();
        }

        /// <summary>
        /// 权限
        /// </summary>
        public string Auth_Id { get; set; }
        /// <summary>
        /// 权限类型
        /// </summary>
        public string AuthorityType { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }

    }
}
