using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：LayuiFW.Model
* 项目描述 ：
* 类 名 称 ：PageRequest
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：LayuiFW.Model
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/24 16:31:07
* 更新时间 ：2018/6/24 16:31:07
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace LayuiFW.Model
{
    /// <summary>
    /// 服务端绑定客户端的分页请求数据
    /// </summary>
    public class PageRequest
    {
        public PageRequest()
        {
            OrderType = "ASC";
            PageNum = 1;
    }
        /// <summary>
        /// 排序的字段
        /// </summary>
        public string OrderFild { get; set; }

        /// <summary>
        /// ASC or Desc
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 第几页
        /// </summary>
        public long PageNum { get; set; }

        /// <summary>
        /// 每页显示几行数据
        /// </summary>
        public long Limit { get; set; }
    }
}
