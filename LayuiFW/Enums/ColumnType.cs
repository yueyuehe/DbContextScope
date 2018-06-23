using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Enums
{
    /// <summary>
    /// 列类型
    /// </summary>
    public enum ColumnType
    {
        /// <summary>
        /// 常规列 默认 无需设定
        /// </summary>
        normal,
        /// <summary>
        /// 复选框列
        /// </summary>
        checkbox,
        /// <summary>
        /// 空列
        /// </summary>
        space,
        /// <summary>
        /// 序号列
        /// </summary>
        numbers,
    }
}
