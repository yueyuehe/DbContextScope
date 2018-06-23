using LayuiFW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Helpers
{
    /// <summary>
    /// 数据帮助类
    /// </summary>
    public class LayDataHelper
    {
        /// <summary>
        /// 将集合转为tree结构
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="nameSelect"></param>
        /// <param name="idSelect"></param>
        /// <param name="pidSelect"></param>
        /// <returns></returns>
        public static List<TreeItem<T>> ToTreeData<T>(IEnumerable<T> connection, Expression<Func<T, string>> nameSelect, Expression<Func<T, string>> idSelect, Expression<Func<T, string>> pidSelect)
        {
            List<TreeItem<T>> nodes = new List<TreeItem<T>>();
            //找到root 
            foreach (var item in connection)
            {
                var node = new TreeItem<T>
                {
                    id = idSelect.Compile()(item),
                    pid = pidSelect.Compile()(item),
                    name = nameSelect.Compile()(item),
                    options = item,
                    childen = new List<TreeItem<T>>()
                };
                nodes.Add(node);
            }
            ///不是root的节点
            List<TreeItem<T>> isChildlNodeList = new List<TreeItem<T>>();
            foreach (var item in nodes)
            {
                //获取节点的子节点
                var childens = nodes.Where(p => p.pid == item.id).ToList();
                item.childen = childens;
                //将子节点的ID存放在非root节点中
                isChildlNodeList.AddRange(childens);
            }
            //从nodes节点中删除是子节点的节点
            foreach (var item in isChildlNodeList)
            {
                nodes.Remove(item);
            }
            return nodes;
        }

        /// <summary>
        /// 将数据转为table的 请求数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static TableData<T> ToTableData<T>(IEnumerable<T> connection, long count = 0)
        {
            TableData<T> model = new TableData<T>();
            model.data = connection.ToList();
            if (count == 0)
            {
                model.count = connection.Count();
            }
            else
            {
                model.count = count;
            }
            return model;
        }

    }
}
