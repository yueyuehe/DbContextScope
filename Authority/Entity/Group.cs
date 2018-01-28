
using System;
using System.Collections.Generic;
namespace Authority.Entity
{
    public partial class Group
    {
        public Group()
        {
            this.User = new HashSet<User>();
            this.Role = new HashSet<Role>();
            this.Childs = new HashSet<Group>();
        }

        public int Id { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// �û�����
        /// </summary>
        public virtual ICollection<User> User { get; set; }
        /// <summary>
        /// Ȩ�޼���
        /// </summary>
        public virtual ICollection<Role> Role { get; set; }
        /// <summary>
        /// ���鼯��
        /// </summary>
        public virtual ICollection<Group> Childs { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual Group Parent { get; set; }


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
