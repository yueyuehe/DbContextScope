using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qqliwuwang.Helper
{
    public class SimditorUploadReturnModel
    {
        /// <summary>
        /// 上传结果
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string file_path { get; set; }


    }
}