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
        /// ��¼����
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// ��¼����
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// ��������
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// ��ӵ�еĽ�ɫ
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// ��ӵ�е�Ȩ��
        /// </summary>
        public virtual ICollection<Authority> Authorities { get; set; }

    }
}
