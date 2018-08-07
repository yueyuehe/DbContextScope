using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Common.Helpers
* 项目描述 ：
* 类 名 称 ：DownHelper
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：Common.Helpers
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/8/4 18:05:13
* 更新时间 ：2018/8/4 18:05:13
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace Common.Helpers
{
    /// <summary>
    /// 文件下载帮助类
    /// </summary>
    public class DownHelper
    {
        /// <summary>
        /// 下载网页图片
        /// </summary>
        /// <param name="url">下载路径</param>
        /// <param name="desPath">目标路径</param>
        /// <returns>网页显示的地址</returns>
        public static string DownLoadFile(string url, string fileType = null)
        {
            var root = PathHepler.WebRoot();
            //创建文件夹
            var folder = Common.Helpers.CommonHelper.CreateFolderPath(PathType.Month);
            folder = Path.Combine("Image", folder);
            //获取文件类型
            if (string.IsNullOrEmpty(fileType))
            {
                fileType = url.Split('.')[url.Split('.').Count() - 1];
                if (fileType.IndexOf("-") != -1)
                {
                    fileType = url.Split('-')[0];
                }
            }
            var fileName = Common.Helpers.CommonHelper.CreateNewFileName("." + fileType);
            var path = Path.Combine(root, folder, fileName);
            //路径不存在则创建新路径
            if (!FileHelper.IsExistDirectory(Path.Combine(root, folder)))
            {
                FileHelper.CreateDirectory(Path.Combine(root, folder));
            }
            var returnPath = Path.Combine(ConfigManagerHelper.GetConfigValue("DoMain"), folder, fileName);
            if (!returnPath.StartsWith("http") && !returnPath.StartsWith("/"))
            {
                returnPath = "/" + returnPath;
            }
            WebClient client = new WebClient();
            client.DownloadFile(url, path);
            return returnPath;
        }
    }
}
