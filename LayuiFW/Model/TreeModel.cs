using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Model
{
    public class TreeModel
    {
        public TreeModel()
        {
            nodes = new List<Node>();
        }
        /// <summary>
        ///指定元素的选择器
        /// </summary>
        public string elem { get; set; }
        /// <summary>
        ///风格定义
        /// </summary>
        public string skin { get; set; }
        /// <summary>
        ///点击节点的回调，详细介绍见下文
        /// </summary>
        public string click { get; set; }

        /// <summary>
        ///节点链接（可选），未设则不会跳转
        /// </summary>
        //public string Href { get; set; }

        /// <summary>
        ///节点打开方式（即a的target值），必须href设定后才有效
        /// </summary>
        public string target { get; set; }

        /// <summary>
        ///节点数据，详细格式见下表
        /// </summary>
        public List<Node> nodes { get; set; }

    }


    public class Node
    {
        public Node()
        {
            children = new List<Node>();
        }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 是否展开 默认false
        /// </summary>
        public bool spread { get; set; }

        /// <summary>
        ///  节点链接（可选），未设则不会跳转
        /// </summary>
       // public string Href { get; set; }

        /// <summary>
        /// 可无限延伸
        /// </summary>
        public List<Node> children { get; set; }

        /// <summary>
        /// 自定义参数
        /// </summary>
        public dynamic options { get; set; }
    }
    
}
