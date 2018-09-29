using HWAdmin.Entity.Base;
using System;
using System.Collections.Generic;

namespace HWAdmin.Entity.System
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public partial class FileAuth : BaseEntity
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


        /// <summary>
        ///  权限表 1-1
        /// </summary>
        public Authority Authority { get; set; }
    }
}
