
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
        /// ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �û�����
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }
        /// <summary>
        /// Ȩ�޼���
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
        /// <summary>
        /// ���鼯��
        /// </summary>
        public virtual ICollection<Group> Childs { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual Group Parent { get; set; }


    }
}
