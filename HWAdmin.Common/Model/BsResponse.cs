using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.Model
* 项目描述 ：
* 类 名 称 ：BsResponse
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.Model
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/26 20:10:17
* 更新时间 ：2018/6/26 20:10:17
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.Model
{
    /// <summary>
    /// Bootstrap-table分页数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BsPageResponse<T>
    {
        public BsPageResponse()
        {
            rows = new List<T>();
        }
        public long total { get; set; }
        public IList<T> rows { get; set; }
        /// <summary>
        /// 用户数据
        /// </summary>
        public decimal userData { get; set; }
    }
    public class BsPageResponse
    {
        public BsPageResponse()
        {
            rows = new List<object>();
        }
        public long total { get; set; }
        public object rows { get; set; }
        /// <summary>
        /// 用户数据
        /// </summary>
        public decimal userData { get; set; }
    }


    public class BsPageRequest
    {
        public BsPageRequest()
        {
            Order = "asc";
            Offset = 0;
            Limit = 10;
        }
        /// <summary>
        /// 排序类型
        /// </summary>
        public string Order { get; set; }
        public long Offset { get; set; }
        /// <summary>
        /// 一页显示多少数据
        /// </summary>
        public long Limit { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public String Sort { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public long PageNum
        {
            get
            {
                return (Offset + Limit) % Limit == 0 ? (Offset + Limit) / Limit : ((Offset + Limit) / Limit) + 1;
            }
            set
            {
                PageNum = value;
            }
        }
    }

}
