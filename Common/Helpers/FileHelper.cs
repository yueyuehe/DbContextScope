using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Common.Helpers
* 项目描述 ：
* 类 名 称 ：FileHelper
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：Common.Helpers
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/24 19:43:33
* 更新时间 ：2018/6/24 19:43:33
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace Common.Helpers
{
    /// <summary>
    ///     文件辅助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        ///     编码方式
        /// </summary>
        private static readonly Encoding Encoding = Encoding.UTF8;

        /// <summary>
        ///     递归取得文件夹下文件
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="list"></param>
        public static void GetFiles(string dir, List<string> list)
        {
            GetFiles(dir, list, new List<string>());
        }

        /// <summary>
        ///     递归取得文件夹下文件
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="list"></param>
        /// <param name="fileExtsions"></param>
        public static void GetFiles(string dir, List<string> list, List<string> fileExtsions)
        {
            //添加文件 
            string[] files = Directory.GetFiles(dir);
            if (fileExtsions.Count > 0)
            {
                foreach (string file in files)
                {
                    string extension = Path.GetExtension(file);
                    if (extension != null && fileExtsions.Contains(extension))
                    {
                        list.Add(file);
                    }
                }
            }
            else
            {
                list.AddRange(files);
            }
            //如果是目录，则递归
            DirectoryInfo[] directories = new DirectoryInfo(dir).GetDirectories();
            foreach (DirectoryInfo item in directories)
            {
                GetFiles(item.FullName, list, fileExtsions);
            }
        }

        /// <summary>
        ///     写入文件
        /// </summary>
        /// <param name="filePath">文件名</param>
        /// <param name="content">文件内容</param>
        public static void WriteFile(string filePath, string content)
        {
            try
            {
                var fs = new FileStream(filePath, FileMode.Create);
                Encoding encode = Encoding;
                //获得字节数组
                byte[] data = encode.GetBytes(content);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        ///     读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFile(string filePath)
        {
            return ReadFile(filePath, Encoding);
        }

        /// <summary>
        ///     读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ReadFile(string filePath, Encoding encoding)
        {
            using (var sr = new StreamReader(filePath, encoding))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        ///     读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> ReadFileLines(string filePath)
        {
            var str = new List<string>();
            using (var sr = new StreamReader(filePath, Encoding))
            {
                String input;
                while ((input = sr.ReadLine()) != null)
                {
                    str.Add(input);
                }
            }
            return str;
        }

        /// <summary>
        ///     复制文件夹（及文件夹下所有子文件夹和文件）
        /// </summary>
        /// <param name="sourcePath">待复制的文件夹路径</param>
        /// <param name="destinationPath">目标路径</param>
        public static void CopyDirectory(String sourcePath, String destinationPath)
        {
            var info = new DirectoryInfo(sourcePath);
            Directory.CreateDirectory(destinationPath);
            foreach (FileSystemInfo fsi in info.GetFileSystemInfos())
            {
                String destName = Path.Combine(destinationPath, fsi.Name);

                if (fsi is FileInfo) //如果是文件，复制文件
                    File.Copy(fsi.FullName, destName);
                else //如果是文件夹，新建文件夹，递归
                {
                    Directory.CreateDirectory(destName);
                    CopyDirectory(fsi.FullName, destName);
                }
            }
        }

        /// <summary>
        ///     删除文件夹（及文件夹下所有子文件夹和文件）
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void DeleteFolder(string directoryPath)
        {
            foreach (string d in Directory.GetFileSystemEntries(directoryPath))
            {
                if (File.Exists(d))
                {
                    var fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly", StringComparison.Ordinal) != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d); //删除文件   
                }
                else
                    DeleteFolder(d); //删除文件夹
            }
            Directory.Delete(directoryPath); //删除空文件夹
        }

        /// <summary>
        ///     清空文件夹（及文件夹下所有子文件夹和文件）
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void ClearFolder(string directoryPath)
        {
            foreach (string d in Directory.GetFileSystemEntries(directoryPath))
            {
                if (File.Exists(d))
                {
                    var fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly", StringComparison.Ordinal) != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d); //删除文件   
                }
                else
                    DeleteFolder(d); //删除文件夹
            }
        }

        /// <summary>
        ///     取得文件大小，按适当单位转换
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFileSimpleSize(string filepath)
        {
            string result = "0KB";
            if (File.Exists(filepath))
            {
                var size = new FileInfo(filepath).Length;
                int filelength = size.ToString().Length;
                if (filelength < 4)
                    result = size + "byte";
                else if (filelength < 7)
                    result = Math.Round(Convert.ToDouble(size / 1024d), 2) + "KB";
                else if (filelength < 10)
                    result = Math.Round(Convert.ToDouble(size / 1024d / 1024), 2) + "MB";
                else if (filelength < 13)
                    result = Math.Round(Convert.ToDouble(size / 1024d / 1024 / 1024), 2) + "GB";
                else
                    result = Math.Round(Convert.ToDouble(size / 1024d / 1024 / 1024 / 1024), 2) + "TB";
                return result;
            }
            return result;
        }


        #region 检测指定目录是否存在  
        /// <summary>  
        /// 检测指定目录是否存在  
        /// </summary>  
        /// <param name="directoryPath">目录的绝对路径</param>          
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        #endregion

        #region 检测指定文件是否存在  
        /// <summary>  
        /// 检测指定文件是否存在,如果存在则返回true。  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }
        #endregion

        #region 检测指定目录是否为空  
        /// <summary>  
        /// 检测指定目录是否为空  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>          
        public static bool IsEmptyDirectory(string directoryPath)
        {
            try
            {
                //判断是否存在文件  
                string[] fileNames = GetFileNames(directoryPath);
                if (fileNames.Length > 0)
                {
                    return false;
                }

                //判断是否存在文件夹  
                string[] directoryNames = GetDirectories(directoryPath);
                return directoryNames.Length <= 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 检测指定目录中是否存在指定的文件  
        /// <summary>  
        /// 检测指定目录中是否存在指定的文件,若要搜索子目录请使用重载方法.  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>          
        public static bool Contains(string directoryPath, string searchPattern)
        {
            try
            {
                //获取指定的文件列表  
                string[] fileNames = GetFileNames(directoryPath, searchPattern, false);

                //判断指定文件是否存在  
                return fileNames.Length != 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>  
        /// 检测指定目录中是否存在指定的文件  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>   
        /// <param name="isSearchChild">是否搜索子目录</param>  
        public static bool Contains(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                //获取指定的文件列表  
                string[] fileNames = GetFileNames(directoryPath, searchPattern, true);

                //判断指定文件是否存在  
                return fileNames.Length != 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 创建一个目录  
        /// <summary>  
        /// 创建一个目录  
        /// </summary>  
        /// <param name="directoryPath">目录的绝对路径</param>  
        public static void CreateDirectory(string directoryPath)
        {
            //如果目录不存在则创建该目录  
            if (!IsExistDirectory(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
        #endregion

        #region 创建一个文件  
        /// <summary>  
        /// 创建一个文件。  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public static bool CreateFile(string filePath)
        {
            try
            {
                //如果文件不存在则创建该文件  
                if (!IsExistFile(filePath))
                {
                    //创建一个FileInfo对象  
                    FileInfo file = new FileInfo(filePath);
                    //创建文件  
                    FileStream fs = file.Create();
                    //关闭文件流  
                    fs.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>  
        /// 创建一个文件,并将字节流写入文件。  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="buffer">二进制流数据</param>  
        public static bool CreateFile(string filePath, byte[] buffer)
        {
            try
            {
                //如果文件不存在则创建该文件  
                if (!IsExistFile(filePath))
                {
                    //创建一个FileInfo对象  
                    FileInfo file = new FileInfo(filePath);

                    //创建文件  
                    FileStream fs = file.Create();

                    //写入二进制流  
                    fs.Write(buffer, 0, buffer.Length);

                    //关闭文件流  
                    fs.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 获取文本文件的行数  
        /// <summary>  
        /// 获取文本文件的行数  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public static int GetLineCount(string filePath)
        {
            //将文本文件的各行读到一个字符串数组中  
            string[] rows = File.ReadAllLines(filePath);

            //返回行数  
            return rows.Length;
        }
        #endregion

        #region 获取一个文件的长度  
        /// <summary>  
        /// 获取一个文件的长度,单位为Byte  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public static int GetFileSize(string filePath)
        {
            //创建一个文件对象  
            FileInfo fi = new FileInfo(filePath);

            //获取文件的大小  
            return (int)fi.Length;
        }

        /// <summary>  
        /// 获取一个文件的长度,单位为KB  
        /// </summary>  
        /// <param name="filePath">文件的路径</param>          
        public static double GetFileSizeByKB(string filePath)
        {
            //创建一个文件对象  
            FileInfo fi = new FileInfo(filePath);
            long size = fi.Length / 1024;
            //获取文件的大小  
            return double.Parse(size.ToString());
        }

        /// <summary>  
        /// 获取一个文件的长度,单位为MB  
        /// </summary>  
        /// <param name="filePath">文件的路径</param>          
        public static double GetFileSizeByMB(string filePath)
        {
            //创建一个文件对象  
            FileInfo fi = new FileInfo(filePath);
            long size = fi.Length / 1024 / 1024;
            //获取文件的大小  
            return double.Parse(size.ToString());
        }
        #endregion

        #region 获取指定目录中的文件列表  
        /// <summary>  
        /// 获取指定目录中所有文件列表  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>          
        public static string[] GetFileNames(string directoryPath)
        {
            //如果目录不存在，则抛出异常  
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }

            //获取文件列表  
            return Directory.GetFiles(directoryPath);
        }

        /// <summary>  
        /// 获取指定目录及子目录中所有文件列表  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>  
        /// <param name="isSearchChild">是否搜索子目录</param>  
        public static string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
        {
            //如果目录不存在，则抛出异常  
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }

            try
            {
                return Directory.GetFiles(directoryPath, searchPattern, isSearchChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 获取指定目录中的子目录列表  
        /// <summary>  
        /// 获取指定目录中所有子目录列表,若要搜索嵌套的子目录列表,请使用重载方法.  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>          
        public static string[] GetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>  
        /// 获取指定目录及子目录中所有子目录列表  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>  
        /// <param name="isSearchChild">是否搜索子目录</param>  
        public static string[] GetDirectories(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                return Directory.GetDirectories(directoryPath, searchPattern, isSearchChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            catch
            {
                throw null;
            }
        }
        #endregion

        #region 向文本文件写入内容  
        /// <summary>  
        /// 向文本文件中写入内容  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="content">写入的内容</param>          
        public static void WriteText(string filePath, string content)
        {
            //向文件写入内容  
            File.WriteAllText(filePath, content);
        }
        #endregion

        #region 向文本文件的尾部追加内容  
        /// <summary>  
        /// 向文本文件的尾部追加内容  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="content">写入的内容</param>  
        public static void AppendText(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }
        #endregion

        #region 将现有文件的内容复制到新文件中  
        /// <summary>  
        /// 将源文件的内容复制到目标文件中  
        /// </summary>  
        /// <param name="sourceFilePath">源文件的绝对路径</param>  
        /// <param name="destFilePath">目标文件的绝对路径</param>  
        public static void Copy(string sourceFilePath, string destFilePath)
        {
            File.Copy(sourceFilePath, destFilePath, true);
        }
        #endregion

        #region 将文件移动到指定目录  
        /// <summary>  
        /// 将文件移动到指定目录  
        /// </summary>  
        /// <param name="sourceFilePath">需要移动的源文件的绝对路径</param>  
        /// <param name="descDirectoryPath">移动到的目录的绝对路径</param>  
        public static void Move(string sourceFilePath, string descDirectoryPath)
        {
            //获取源文件的名称  
            string sourceFileName = GetFileName(sourceFilePath);

            if (IsExistDirectory(descDirectoryPath))
            {
                //如果目标中存在同名文件,则删除  
                if (IsExistFile(descDirectoryPath + "\\" + sourceFileName))
                {
                    DeleteFile(descDirectoryPath + "\\" + sourceFileName);
                }
                //将文件移动到指定目录  
                File.Move(sourceFilePath, descDirectoryPath + "\\" + sourceFileName);
            }
        }
        #endregion

        #region 将流读取到缓冲区中  
        /// <summary>  
        /// 将流读取到缓冲区中  
        /// </summary>  
        /// <param name="stream">原始流</param>  
        public static byte[] StreamToBytes(Stream stream)
        {
            try
            {
                //创建缓冲区  
                byte[] buffer = new byte[stream.Length];

                //读取流  
                stream.Read(buffer, 0, int.Parse(stream.Length.ToString()));

                //返回流  
                return buffer;
            }
            catch
            {
                return null;
            }
            finally
            {
                //关闭流  
                stream.Close();
            }
        }
        #endregion

        #region 将文件读取到缓冲区中  
        /// <summary>  
        /// 将文件读取到缓冲区中  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public static byte[] FileToBytes(string filePath)
        {
            //获取文件的大小   
            int fileSize = GetFileSize(filePath);

            //创建一个临时缓冲区  
            byte[] buffer = new byte[fileSize];

            //创建一个文件流  
            FileInfo fi = new FileInfo(filePath);
            FileStream fs = fi.Open(FileMode.Open);

            try
            {
                //将文件流读入缓冲区  
                fs.Read(buffer, 0, fileSize);

                return buffer;
            }
            catch
            {
                return null;
            }
            finally
            {
                //关闭文件流  
                fs.Close();
            }
        }
        #endregion

        #region 将文件读取到字符串中  
        /// <summary>  
        /// 将文件读取到字符串中  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public static string FileToString(string filePath)
        {
            return FileToString(filePath, Encoding.Default);
        }
        /// <summary>  
        /// 将文件读取到字符串中  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="encoding">字符编码</param>  
        public static string FileToString(string filePath, Encoding encoding)
        {
            //创建流读取器  
            StreamReader reader = new StreamReader(filePath, encoding);
            try
            {
                //读取流  
                return reader.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                //关闭流读取器  
                reader.Close();
            }
        }
        #endregion

        #region 从文件的绝对路径中获取文件名( 包含扩展名 )  
        /// <summary>  
        /// 从文件的绝对路径中获取文件名( 包含扩展名 )  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public static string GetFileName(string filePath)
        {
            //获取文件的名称  
            FileInfo fi = new FileInfo(filePath);
            return fi.Name;
        }
        #endregion

        #region 从文件的绝对路径中获取文件名( 不包含扩展名 )  
        /// <summary>  
        /// 从文件的绝对路径中获取文件名( 不包含扩展名 )  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public static string GetFileNameNoExtension(string filePath)
        {
            //获取文件的名称  
            FileInfo fi = new FileInfo(filePath);
            return fi.Name.Split('.')[0];
        }
        #endregion

        #region 从文件的绝对路径中获取扩展名  
        /// <summary>  
        /// 从文件的绝对路径中获取扩展名  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public static string GetExtension(string filePath)
        {
            //获取文件的名称  
            FileInfo fi = new FileInfo(filePath);
            return fi.Extension;
        }
        #endregion

        #region 清空指定目录  
        /// <summary>  
        /// 清空指定目录下所有文件及子目录,但该目录依然保存.  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        public static void ClearDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                //删除目录中所有的文件  
                string[] fileNames = GetFileNames(directoryPath);
                foreach (string t in fileNames)
                {
                    DeleteFile(t);
                }

                //删除目录中所有的子目录  
                string[] directoryNames = GetDirectories(directoryPath);
                foreach (string t in directoryNames)
                {
                    DeleteDirectory(t);
                }
            }
        }
        #endregion

        #region 清空文件内容  
        /// <summary>  
        /// 清空文件内容  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public static void ClearFile(string filePath)
        {
            //删除文件  
            File.Delete(filePath);

            //重新创建该文件  
            CreateFile(filePath);
        }
        #endregion

        #region 删除指定文件  
        /// <summary>  
        /// 删除指定文件  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public static void DeleteFile(string filePath)
        {
            if (IsExistFile(filePath))
            {
                File.Delete(filePath);
            }
        }
        #endregion

        #region 删除指定目录  
        /// <summary>  
        /// 删除指定目录及其所有子目录  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        public static void DeleteDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }
        #endregion

        #region 记录错误日志到文件方法  
        /// <summary>  
        /// 记录错误日志到文件方法  
        /// </summary>  
        /// <param name="exMessage"></param>  
        /// <param name="exMethod"></param>  
        /// <param name="userID"></param>  
        public static void ErrorLog(string exMessage, string exMethod, int userID)
        {
            try
            {
                string errVir = "/Log/Error/" + DateTime.Now.ToShortDateString() + ".txt";
                string errPath = System.Web.HttpContext.Current.Server.MapPath(errVir);
                File.AppendAllText(errPath,
                                   "{userID:" + userID + ",exMedthod:" + exMethod + ",exMessage:" + exMessage + "}");
            }
            catch
            {

            }
        }
        #endregion

        #region 输出调试日志  
        /// <summary>  
        /// 输出调试日志  
        /// </summary>  
        /// <param name="factValue">实际值</param>   
        /// <param name="expectValue">预期值</param>  
        public static void OutDebugLog(object factValue, object expectValue = null)
        {
            string errPath = System.Web.HttpContext.Current.Server.MapPath(string.Format("/Log/Debug/{0}.html", DateTime.Now.ToShortDateString()));
            if (!Equals(expectValue, null))
                File.AppendAllLines(errPath,
                                   new[]{string.Format(
                                       "【{0}】[{3}] 实际值:<span style='color:blue;'>{1}</span> 预期值: <span style='color:gray;'>{2}</span><br/>",
                                       DateTime.Now.ToShortTimeString()
                                       , factValue, expectValue, Equals(expectValue, factValue)
                                           ? "<span style='color:green;'>成功</span>"
                                           : "<span style='color:red;'>失败</span>")});
            else
                File.AppendAllLines(errPath, new[]{
                               string.Format(
                                   "【{0}】[{3}] 实际值:<span style='color:blue;'>{1}</span> 预期值: <span style='color:gray;'>{2}</span><br/>",
                                   DateTime.Now.ToShortTimeString()
                                   , factValue, "空", "<span style='color:green;'>成功</span>")});
        }
        #endregion

    }

}
