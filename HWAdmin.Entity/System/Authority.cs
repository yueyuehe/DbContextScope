using HWAdmin.Entity.Base;
using HWAdmin.Entity.Enum;
using System;
using System.Collections.Generic;

namespace HWAdmin.Entity.System
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
        /// 权限（菜单,文件,按钮,操作,页面元素）
        /// </summary>
        public string Auth_Id { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public AuthorityType AuthType { get; set; }

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
