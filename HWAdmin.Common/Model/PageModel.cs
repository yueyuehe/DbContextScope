using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.Model
* 项目描述 ：
* 类 名 称 ：PageModel
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.Model
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/8/7 22:11:11
* 更新时间 ：2018/8/7 22:11:11
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.Model
{
    /// <summary>
    /// 分页模型
    /// </summary>
    public class PageModel
    {
        /// <summary>
        /// 每页显示的数量
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNum { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// 当前页的数据
        /// </summary>
        public List<object> PageData { get; set; }

    }
}
