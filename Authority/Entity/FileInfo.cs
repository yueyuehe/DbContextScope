using System;
using System.Collections.Generic;

namespace Authority.Basic
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public partial class FileInfo : BaseEntity
    {


        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
       
        /// <summary>
        /// 文件地址
        /// </summary>
        public string FilePath { get; set; }
      
        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 文件的保存名称
        /// </summary>
        public string FileSaveName { get; set; }
    }
}
