using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Common.Entity
* 项目描述 ：
* 类 名 称 ：OperationLog
* 类 描 述 ：日志实体
* 所在的域 ：yueyuehe-PC
* 命名空间 ：Common.Entity
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/6 23:52:20
* 更新时间 ：2018/6/6 23:52:20
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace Common.Entity
{
    public class OperationLog
    {
        public string Id { get; set; }
        public string Host { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public string Querystring { get; set; }
        public string FormParams { get; set; }
        public string Url { get; set; }
        public string Cookie { get; set; }
        public string Ip { get; set; }
        public string Account_Id { get; set; }
        public string Useragent { get; set; }
        public string Referrer { get; set; }
        public DateTime DateTime { get; set; }
        public string Operation { get; set; }
        public string ExecuteStatus { get; set; }
        public string ErrorMs { get; set; }
    }
}
