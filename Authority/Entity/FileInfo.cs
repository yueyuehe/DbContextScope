using System;
using System.Collections.Generic;

namespace Authority.Entity
{
    /// <summary>
    /// �ļ���Ϣ
    /// </summary>
    public partial class FileInfo : BaseEntity
    {


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
        /// �ļ��ı�������
        /// </summary>
        public string FileSaveName { get; set; }
    }
}
