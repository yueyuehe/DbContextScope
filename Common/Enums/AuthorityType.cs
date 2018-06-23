using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Common.Enums
* 项目描述 ：
* 类 名 称 ：AuthorityType
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：Common.Enums
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/7 21:34:30
* 更新时间 ：2018/6/7 21:34:30
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace Common.Enums
{
    /// <summary>
    /// 权限的类型
    /// </summary>
    public enum AuthorityType
    {
        /// <summary>
        /// 功能方法
        /// </summary>
        Action,
        /// <summary>
        /// 文件权限 类似于Action 其实可以不做区分
        /// </summary>
        File,
        /// <summary>
        /// 页面元素 如按钮
        /// </summary>
        PageElement,
        /// <summary>
        /// 菜单
        /// </summary>
        Menu,
        /// <summary>
        /// 表字段 有的表字段只有有权限的人才可以浏览
        /// </summary>
        Field

    }
}
