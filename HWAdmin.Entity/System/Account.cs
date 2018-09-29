using HWAdmin.Entity.Base;
using System;
using System.Collections.Generic;

namespace HWAdmin.Entity.System
{
    public partial class Account : BaseEntity
    {

        public Account()
        {
            this.Groups = new HashSet<Group>();
            this.Roles = new HashSet<Role>();
            this.Authorities = new HashSet<Authority>();
        }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// 所属部门
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// 所拥有的角色
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// 所拥有的权限
        /// </summary>
        public virtual ICollection<Authority> Authorities { get; set; }

    }
}
