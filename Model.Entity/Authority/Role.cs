
using System;
using System.Collections.Generic;

namespace Model.Entity.Authority
{

    public partial class Role
    {
        public Role()
        {
            this.User = new HashSet<User>();
            this.Group = new HashSet<Group>();
            this.Authority = new HashSet<Authority>();
        }

        public int Id { get; set; }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// �û�����
        /// </summary>
        public virtual ICollection<User> User { get; set; }
        /// <summary>
        /// �鼯��
        /// </summary>
        public virtual ICollection<Group> Group { get; set; }
        /// <summary>
        /// Ȩ�޼���
        /// </summary>
        public virtual ICollection<Authority> Authority { get; set; }


        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual User CreateUser { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public virtual User UpdateUser { get; set; }
    }
}
