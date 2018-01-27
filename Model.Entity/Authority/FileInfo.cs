using System;
using System.Collections.Generic;

namespace Model.Entity.Authority
{
    public partial class FileInfo
    {
        public FileInfo()
        {
            this.Authority = new HashSet<Authority>();
        }
    
        public int Id { get; set; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// �ļ���ַ
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }

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
