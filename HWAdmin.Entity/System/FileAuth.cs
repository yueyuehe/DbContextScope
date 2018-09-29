using HWAdmin.Entity.Base;
using System;
using System.Collections.Generic;

namespace HWAdmin.Entity.System
{
    /// <summary>
    /// �ļ���Ϣ
    /// </summary>
    public partial class FileAuth : BaseEntity
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


        /// <summary>
        ///  Ȩ�ޱ� 1-1
        /// </summary>
        public Authority Authority { get; set; }
    }
}
