using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace qqliwuwang.BLL
{
    /// <summary>
    /// 文件操作类 用户保存上传的文件
    /// </summary>
    public class FileManage
    {

        /// <summary>
        /// 创建新的文件路径
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filetype"></param>
        /// <returns></returns>
        public string CreateFileName(ImageType type, string file)
        {
            var arr = file.Split('.');
            var filetype = arr[arr.Length - 1];
            //var rootPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            var path = Path.Combine("/Image", type.ToString(), DateTime.Now.ToString("yyyyMM"));
            var fileName = DateTime.Now.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 4) + "." + filetype;
            path = Path.Combine(path, fileName);
            return path;
        }
    }

    public enum ImageType
    {
        Article,
        Goods
    }
}