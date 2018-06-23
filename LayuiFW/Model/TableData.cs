using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Model
{

    /// <summary>
    /// 表格数据结构
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
}
