using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.Model
* 项目描述 ：
* 类 名 称 ：ResponseData
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.Model
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/8/4 18:16:26
* 更新时间 ：2018/8/4 18:16:26
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.Model
{
    /// <summary>
    /// 作为JSON数据模型 返回
    /// </summary>
    public class ResponseData
    {
        public ResponseData()
        {
            this.Success = true;
            this.Message = "操作成功";
            this.UserData = new System.Dynamic.ExpandoObject(); //动态类型字段 可读可写
        }
        /// <summary>
        /// 执行状态
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 用户数据
        /// </summary>
        public object UserData { get; set; }

    }
}
