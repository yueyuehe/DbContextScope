﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace HWAdmin.Common.Helpers
{
    /// <summary>
    /// 常用公共类
    /// </summary>
    public class CommonHelper
    {
        #region Stopwatch计时器
        /// <summary>
        /// 计时器开始
        /// </summary>
        /// <returns></returns>
        public static Stopwatch TimerStart()
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            return watch;
        }
        /// <summary>
        /// 计时器结束
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public static string TimerEnd(Stopwatch watch)
        {
            watch.Stop();
            double costtime = watch.ElapsedMilliseconds;
            return costtime.ToString();
        }
        #endregion

        #region 删除数组中的重复项
        /// <summary>
        /// 删除数组中的重复项
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string[] RemoveDup(string[] values)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < values.Length; i++)//遍历数组成员
            {
                if (!list.Contains(values[i]))
                {
                    list.Add(values[i]);
                };
            }
            return list.ToArray();
        }
        #endregion

        #region 自动生成日期编号
        /// <summary>
        /// 自动生成编号  201008251145409865
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); //生成编号 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;//形如
            return code;
        }
        #endregion

        #region 生成0-9随机数
        /// <summary>
        /// 生成0-9随机数
        /// </summary>
        /// <param name="codeNum">生成长度</param>
        /// <returns></returns>
        public static string RndNum(int codeNum)
        {
            StringBuilder sb = new StringBuilder(codeNum);
            Random rand = new Random();
            for (int i = 1; i < codeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
        #endregion

        #region 删除最后一个字符之后的字符
        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }
        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        /// <summary>
        /// 删除最后结尾的长度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string DelLastLength(string str, int Length)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            str = str.Substring(0, str.Length - Length);
            return str;
        }
        #endregion

        #region 创建新的文件名称 yyyyMMddHHmmss_guid的前4位

        /// <summary>
        /// 创建新的文件名称 yyyyMMddHHmmss_guid的前4位
        /// </summary>
        /// <returns></returns>
        public static string CreateNewFileName(string file)
        {
            var arr = file.Split('.');
            var filetype = arr[arr.Length - 1];
            return string.Format("{0}_{1}.{2}", DateTime.Now.ToString("yyyyMMddHHmmss"), Guid.NewGuid().ToString().Substring(0, 4), filetype);
        }

        #endregion


        #region 创建文件路径

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <returns></returns>
        public static string CreateFolderPath(PathType pathType)
        {
            var date = DateTime.Now;
            switch (pathType)
            {
                case PathType.Day:
                    return Path.Combine(date.ToString("yyyy"), date.ToString("yyyyMM"), date.ToString("yyyyMMdd"));
                case PathType.Year:
                    return Path.Combine(date.ToString("yyyy"));
                case PathType.Month:
                    return Path.Combine(date.ToString("yyyy"), date.ToString("yyyyMM"));
                default:
                    return "";

            }


        }





        #endregion

    }

    public enum PathType
    {
        Year, Month, Day
    }
}
