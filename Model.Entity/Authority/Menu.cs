using System;
using System.Collections.Generic;

namespace Model.Entity.Authority
{
    public partial class Menu
    {
        public Menu()
        {
            this.Authority = new HashSet<Authority>();
            this.Childs = new HashSet<Menu>();
        }
        public int Id { get; set; }
        /// <summary>
        /// �˵�����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �˵�URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Ȩ��
        /// </summary>
        public virtual ICollection<Authority> Authority { get; set; }
        /// <summary>
        /// �Ӳ˵�
        /// </summary>
        public virtual ICollection<Menu> Childs { get; set; }

        /// <summary>
        /// ���˵�
        /// </summary>
        public virtual Menu Parent { get; set; }


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
