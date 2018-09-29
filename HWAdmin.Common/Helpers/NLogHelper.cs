using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.Helpers
* 项目描述 ：
* 类 名 称 ：NLogHelper
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.Helpers
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/5/24 20:55:15
* 更新时间 ：2018/5/24 20:55:15
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion 
namespace HWAdmin.Common.Helpers
{
    public class NLogHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }
        public static void Error(Exception exp)
        {
            logger.Error(exp);
        }

        public static void Warn(string message)
        {
            logger.Warn(message);
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }
        public static void Info(LogEventInfo eventInfo)
        {
            logger.Info(eventInfo);
        }
        public static void Debug(string message)
        {
            logger.Debug(message);
        }
        public static void Trace(string message)
        {
            logger.Trace(message);
        }


    }
}
