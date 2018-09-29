using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.Common.Model
{
    /// <summary>
    /// treeItem数据结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeItem<T>
    {
        public string id { get; set; }

        public string pid { get; set; }

        public string name { get; set; }

        public T options { get; set; }


        public IEnumerable<TreeItem<T>> childen { get; set; }

    }
}
