using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.Helpers
* 项目描述 ：
* 类 名 称 ：PathHepler
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.Helpers
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/7/20 23:29:29
* 更新时间 ：2018/7/20 23:29:29
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.Helpers
{
    public class PathHepler
    {
        #region 取得控制台应用程序的根目录方法

        /// <summary>
        ///取得或设置当前工作目录的完整限定路径
        /// </summary>
        /// <returns></returns>
        public static string ConsoleRootPath()
        {
            return Environment.CurrentDirectory;
        }

        /// <summary>
        /// 获取基目录，它由程序集冲突解决程序用来探测程序集
        /// </summary>
        /// <returns></returns>
        public static string ConsoleRoot()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        #endregion




        #region 取得WinForm应用程序的根目录方法

        /// <summary>
        /// 获取或设置当前工作目录的完全限定路径
        /// </summary>
        /// <returns></returns>
        public static string CurrentDirectory()
        {
            return Environment.CurrentDirectory.ToString();
        }

        /// <summary>
        /// 获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称
        /// </summary>
        /// <returns></returns>
        public static string AppStartupPath()
        {
            //return Application.StartupPath.ToString();
            return "";
        }

        /// <summary>
        /// 获取应用程序的当前工作目录
        /// </summary>
        /// <returns></returns>
        public static string AppCurrentDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }


        /// <summary>
        /// /获取基目录，它由程序集冲突解决程序用来探测程序集
        /// </summary>
        /// <returns></returns>
        public static string AppBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        /// <summary>
        /// 获取或设置包含该应用程序的目录的名称
        /// </summary>
        /// <returns></returns>
        public static string ApplicationBase()
        {
            return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        #endregion



        #region  取得web应用程序的根目录方法 HttpContext.Current 获取当前的HttpContext对象 可直接访问Request Response Session Application

        /// <summary>
        /// 转为绝对路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToAbsolutePath(string path)
        {
            return System.Web.HttpContext.Current.Server.MapPath(Path.Combine("~", path));
        }

        /// <summary>
        /// 获取网站的根目录
        /// </summary>
        /// <returns></returns>
        public static string WebRoot()
        {
            return System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
        }

        /// <summary>
        /// 这个获取的是文件的路径而不是根目录
        /// </summary>
        /// <returns></returns>
        public static string FileRoot()
        {
            return System.Web.HttpContext.Current.Server.MapPath("~");
        }
        #endregion
    }
}
