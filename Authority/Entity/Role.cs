
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
        /// ��ɫ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �û�����
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }

        /// <summary>
        /// �鼯��
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// Ȩ�޼���
        /// </summary>
        public virtual ICollection<Authority> Authorities { get; set; }

    }
}
