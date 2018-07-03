using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Model
{

    /// <summary>
    /// 表格数据结构 返回的数据 通过json序列化成字符串返回给客户端
    /// </summary>
    public class TableData<T>
    {
        public TableData()
        {
            data = new List<T>();
        }
        public int code { get; set; }
        public string msg { get; set; }
        public long count { get; set; }
        public List<T> data { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }

    public class TableData
    {
        public TableData()
        {
            data = new List<object>();
        }
        public int code { get; set; }
        public string msg { get; set; }
        public long count { get; set; }
        public object data { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }

    /// <summary>
    /// layui 表格数据接口模型
    /// </summary>
    public class PageResponse
    {
        public PageResponse()
        {
            data = new List<object>();
        }
        /// <summary>
        /// 代码 默认0
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回的状态消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long count { get; set; }
        /// <summary>
        /// 数据列表
        /// </summary>
        public object data { get; set; }
      
    }

}
