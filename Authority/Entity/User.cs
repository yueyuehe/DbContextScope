using System;
using System.Collections.Generic;

namespace Authority.Entity
{
    public partial class User
    {
        public User()
        {
            this.Group = new HashSet<Group>();
            this.Role = new HashSet<Role>();
        }

        public int Id { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        public string Password { get; set; }

        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<Role> Role { get; set; }

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
