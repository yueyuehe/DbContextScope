
using System;
using System.Collections.Generic;

namespace Model.Entity.Authority
{

    public partial class PageElement
    {
        public PageElement()
        {
            this.Authority = new HashSet<Authority>();
        }

        public int Id { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

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
