using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.Enums
* 项目描述 ：
* 类 名 称 ：RequestMethod
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.Enums
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/7 21:02:00
* 更新时间 ：2018/6/7 21:02:00
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.Enums
{
    public enum RequestMethod
    {
        ///user/:id # 获取id用户的信息 
        GET = 1,
        ///user # 创建新的用户（注册） 
        POST = 2,
        ///user/:id # 更新id用户的信息 
        PUT = 4,
        ///user/:id # 删除id用户（注销）
        DELETE = 8
    }
}
