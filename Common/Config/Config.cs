using Common.Config.AppStr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Common.Config
* 项目描述 ：
* 类 名 称 ：ConfigHelper
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：Common.Config
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/5/23 23:30:52
* 更新时间 ：2018/5/23 23:30:52
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace Common.Config
{
    /// <summary>
    /// 可将数据加密
    /// </summary>
    public class ConfigParam
    {
        /// <summary>
        /// 用户信息在session中的保存形式
        /// </summary>
        public const string Session_Account = "Session_Account";
        /// <summary>
        /// Action执行结果 保存在当前线程中（true:false）
        /// </summary>
        public const string ActionExecute_Status = "ActionExecute_Status";

        /// <summary>
        /// 上下文的账户ID
        /// </summary>
        public const string HttpContext_Account_ID = "HttpContext_Account_ID";

        /// <summary>
        /// 一个线程中的action执行状态
        /// </summary>
        public const string ActionLog_Execute_Flag = "ActionLog_Execute_Flag";


        /// <summary>
        /// 操作日志记录开启字符串
        /// </summary>
        public const string ActionLog_Open_Flag = "OperationLog";

        /// <summary>
        /// 何种请求类型需要记录操作日志
        /// </summary>
        public const string ActionLog_Open_Allow_Method = "OperationLog_Allow_Method";

        /// <summary>
        /// session中权限的key键
        /// </summary>
        public const string Authority_All_Session = "Authority_All_Session";

    }




}
