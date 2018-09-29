using HWAdmin.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.Model
* 项目描述 ：
* 类 名 称 ：AuthorityModel
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.Model
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/7 21:41:57
* 更新时间 ：2018/6/7 21:41:57
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.Model
{

    /// <summary>
    /// 权限的模型数据 在程序启动的时候就从数据库或配置文件文件汇总读取权限存放到session中
    /// </summary>
    public class AuthorityModel
    {
        /// <summary>
        /// 存储所有的 权限 
        /// </summary>
        public Dictionary<AuthorityType, List<string>> AllAuthority { get; set; }

        //根据权限类型获取权限
        public List<string> Authority(AuthorityType type)
        {
            return AllAuthority[type];
        }


        //直接访问权限
        public List<string> ActionAuthority
        {
            get
            {
                return AllAuthority[AuthorityType.Action];
            }
        }

        public List<string> FiltAuthority
        {
            get
            {
                return AllAuthority[AuthorityType.File];
            }
        }

        public List<string> FieldAuthority
        {
            get
            {
                return AllAuthority[AuthorityType.Field];
            }
        }

        public List<string> MenuAuthority
        {
            get
            {
                return AllAuthority[AuthorityType.Menu];
            }
        }

        public List<string> PageElementAuthority
        {
            get
            {
                return AllAuthority[AuthorityType.PageElement];
            }
        }

        //添加权限

        public void AddAuthority(List<string> list, AuthorityType type)
        {
            if (AllAuthority.Keys.Contains(type))
            {
                AllAuthority[type].AddRange(list);
            }
            else
            {
                AllAuthority.Add(type, list);
            }
        }

        //删除权限
        public void RemoveAuthority(AuthorityType type)
        {
            AllAuthority.Remove(type);
        }

        public void RemoveAuthority(AuthorityType type, List<string> list)
        {
            if (AllAuthority.ContainsKey(type))
            {
                foreach (var item in list)
                {
                    AllAuthority[type].Remove(item);
                }
            }
        }

    }
}
