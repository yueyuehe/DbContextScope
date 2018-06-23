using LayuiFW.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LayColumnAttribute : Attribute
    {
        public LayColumnAttribute() {
            Type = ColumnType.normal;
            FixedType = FixedType.df;
            Edit = EditType.NoEdit;
            Align = AlignType.center;
        }
        /// <summary>
        /// （必填项）设定字段名。字段名的设定非常重要，且是表格数据列的唯一标识 
        ///  默认值为 属性字段
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// （必填项）设定标题名称  
        /// 默认值为 属性字段值 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 设定列宽（默认自动分配）。支持填写：数字、百分比。请结合实际情况，对不同列做不同设定。
        /// 注意：如果是 layui 2.2.0 之前的版本，列宽必须设定一个固定数字	
        /// 例:200 | 30%
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        ///（layui 2.2.1 新增）局部定义当前常规单元格的最小宽度（默认：60），
        ///一般用于列宽自动分配的情况。其优先级高于基础参数中的 cellMinWidth	
        /// 例：100
        /// </summary>
        public string MinWidth { get; set; }
       
        /// <summary>
        ///设定列类型。可选值有：normal（常规列，无需设定）、checkbox（复选框列）、
        ///space（空列）、numbers（序号列）。
        ///注意：该参数为 layui 2.2.0 新增。而如果是之前的版本，
        ///复选框列采用 checkbox: true、空列采用 space: true	任意一个可选值
        /// </summary>
        public ColumnType Type { get; set; }

        /// <summary>
        ///是否全选状态（默认：false）。必须复选框列开启后才有效，如果设置 true，则表示复选框默认全部选中。	true
        /// </summary>
        public bool LAY_CHECKED { get; set; }

        /// <summary>
        /// 
        ///固定列。可选值有：left（固定在左）、right（固定在右）。一旦设定，对应的列将会被固定在左或右，不随滚动条而滚动。 
        ///注意：如果是固定在左，该列必须放在表头最前面；如果是固定在右，该列必须放在表头最后面。	left（同 true）
        ///right
        /// </summary>
        public FixedType FixedType { get; set; }

        /// <summary>
        ///  是否允许排序（默认：false）。如果设置 true，则在对应的表头显示排序icon，从而对列开启排序功能。
        /// 注意：不推荐对值同时存在“数字和普通字符”的列开启排序，因为会进入字典序比对。比如：'贤心' > '2' > '100'，这可能并不是你想要的结果，但字典序排列算法（ASCII码比对）就是如此。
        /// true
        /// </summary>
        public bool Sort { get; set; }

        /// <summary>
        ///是否禁用拖拽列宽（默认：false）。默认情况下会根据列类型（type）来决定是否禁用，如复选框列，会自动禁用。而其它普通列，默认允许拖拽列宽，当然你也可以设置 true 来禁用该功能。	false
        /// </summary>
        public bool Unresize { get; set; }



        /// <summary>
        /// 单元格编辑类型（默认不开启）目前只支持：text（输入框）	text
        /// </summary>
        public EditType Edit { get; set; }



        /// <summary>
        /// 自定义单元格点击事件名，以便在 tool 事件中完成对该单元格的业务处理 任意字符
        /// </summary>
        public string EventClick { get; set; }

        /// <summary>
        ///自定义单元格样式。即传入 CSS 样式 background-color: #5FB878; color: #fff;
        /// </summary>
        public string Style { get; set; }


        /// <summary>
        ///单元格排列方式。可选值有：left（默认）、center（居中）、right（居右）	center
        /// </summary>
        public AlignType Align { get; set; }

        public string Toolbar { get; set; }

        /// <summary>
        /// templet function(d){retrun d}
        /// </summary>
        public string Templet { get; set; }

        public string Colspan { get; set; }

        public string Rowspan { get; set; }


    }
}
