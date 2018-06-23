using Common.Model;
using LayuiFW.Attributes;
using LayuiFW.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWAdmin.Models
{
    /// <summary>
    /// 组织显示的数据
    /// </summary>
    public class GroupModel : LayTable
    {
        [LayColumn(Type = LayuiFW.Enums.ColumnType.numbers)]
        public string Id { get; set; }
        [Description("组织名称")]
        [Input(Placeholder = "请输入名称", Maxlength = "2", MinNumber = "2")]
        [LayColumn(Title = "组织名称")]
        public string Name { get; set; }
        [LayColumn(Title = "描述")]
        public string Description { get; set; }
        [LayColumn(Title = "父ID")]
        public string Parent_Id { get; set; }
    }
}