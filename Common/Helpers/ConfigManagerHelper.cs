using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Common.Helpers
* 项目描述 ：
* 类 名 称 ：ConfigManagerHelper
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：Common.Helpers
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/7/20 23:06:08
* 更新时间 ：2018/7/20 23:06:08
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace Common.Helpers
{
    public  class ConfigManagerHelper
    {
        public static string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }
}
