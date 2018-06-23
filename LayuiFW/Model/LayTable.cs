using LayuiFW.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Model
{
    public class LayTable
    {
        public LayTable()
        {
            Method = "get";
            Page = true;
            Limits = new Int32[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            Loading = true;
            ControlId = "layTable";
            Skin = SkinType.df;
            Size = SizeType.df;
            Height = "full-20";
        }
        //设置表头。值是一个二维数组。方法渲染方式必填 详见表头参数
        //public object[] cols { get; set; }
        //（等）	-	异步数据接口相关参数。其中 url 参数为必填项 详见异步接口
        public string Url { get; set; }

        public string Method { get; set; }

        // 设定容器宽度。table容器的默认宽度是跟随它的父元素铺满，你也可以设定一个固定值，当容器中的内容超出了该宽度时，会自动出现横向滚动条。	1000
        public string Width { get; set; }
        //设定容器高度  详见height
        public string Height { get; set; }
        //（layui 2.2.1 新增）全局定义所有常规单元格的最小宽度（默认：60），一般用于列宽自动分配的情况。其优先级低于表头参数中的 minWidth	100
        public string CellMinWidth { get; set; }
        //数据渲染完的回调。你可以借此做一些其它的操作 详见done回调
        public string Done { get; set; }
        // 直接赋值数据。既适用于只展示一页数据，也非常适用于对一段已知数据进行多页展示。	[{}, {}, {}, {}, …]
        public string Data { get; set; }
        //开启分页（默认：false） 注：从 layui 2.2.0 开始，支持传入一个对象，里面可包含 laypage 组件所有支持的参数（jump、elem除外）	{theme: '#c00'}
        public bool Page { get; set; }
        //每页显示的条数（默认：10）。值务必对应 limits 参数的选项。
        //优先级低于 page //参数中的 limit 参数。	30
        public int? Limit { get; set; }
        // 每页条数的选择项，默认：[10,20,30,40,50,60,70,80,90]。
        //优先级低于 page //参数中的 limits 参数。	[30,60,90]
        public Int32[] Limits { get; set; }
        //是否显示加载条（默认：true）。如果设置 false，则在切换分页时，不会出现加载条。该参数只适用于 url 参数开启的方式	false
        public bool Loading { get; set; }
        // 自定义文本，如空数据时的异常提示等。注：layui 2.2.5 开始新增。	详见自定义文本
        public string Text { get; set; }
        //初始排序状态。用于在数据表格渲染完毕时，默认按某个字段排序。注：该参数为 layui 2.1.1 新增 详见初始排序
        public string Sortfield { get; set; }
        public string SortType { get; set; }

        //设定容器唯一ID。注意：从 layui 2.2.0 开始，该参数等价于<table id="test"></table> 中的 id 值。id值是对表格的数据操作方法上是必要的传递条件，它是表格容器的索引。你在下文也将会见识它的存在。	test
        public string ControlId { get; set; }

        public SkinType Skin { get; set; }

        /// <summary>
        /// 是否开启隔行变色
        /// </summary>
        public bool Even { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public SizeType Size { get; set; }
    }
}
