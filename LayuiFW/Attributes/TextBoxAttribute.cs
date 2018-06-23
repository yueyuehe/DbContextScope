using LayuiFW.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class TextBoxAttribute : Attribute
    {
        public TextBoxAttribute()
        {
            Name = null;
            Id = null;
            Placeholder = null;
            NullDisplayText = null;
            Height = null;
            MaxNumber = null;
            MinNumber = null;
            Pattern = null;
            Value = null;
            Width = null;
            Maxlength = null;
            DisplayType = DisplayType.block;
            LayFilter = null;
            Verify = null;
        }
        public VerifyType[] Verify { get; set; }

        public string LayFilter { get; set; }
        /// <summary>
        /// 只读 默认false
        /// </summary>
        public virtual bool IsReadOnly { get; set; }
        /// <summary> 
        /// 必须 默认false
        /// </summary>
        public virtual bool IsRequired { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public virtual bool IsDisabled { get; set; }

        /// <summary>
        /// 标签name值 默认为字段属性名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 标签id值 默认为Name值
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public virtual string Placeholder { get; set; }


        /// <summary>
        /// 显示的值 如 字段为name 显示为 '名称'
        /// </summary>
        public virtual DisplayType DisplayType { get; set; }

        /// <summary>
        /// input输入框中没有值时显示的数据
        /// </summary>
        public virtual string NullDisplayText { get; set; }

        /// <summary>
        ///  像素pixels 或 % 如：10px, 10%
        /// </summary>
        public virtual string Height { get; set; }

        /// <summary>
        /// 规定输入字段的最大值。
        ///请与 "min" 属性配合使用，来创建合法值的范围。
        /// </summary>
        public virtual long? MaxNumber { get; set; }

        public virtual long? MinNumber { get; set; }


        /// <summary>
        /// 规定输入字段的值的模式或格式。
        ///例如 pattern = "[0-9]" 表示输入值必须是 0 与 9 之间的数字。
        /// </summary>
        public virtual string Pattern { get; set; }

        /// <summary>
        /// input 元素的值
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// 像素pixels 或 % 如：10px, 10%
        /// </summary>
        public virtual string Width { get; set; }

        /// <summary>
        /// 输入字段中的字符的最大长度。
        /// </summary>
        public virtual string Maxlength { get; set; }
    }
}
