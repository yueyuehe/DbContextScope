using HWAdmin.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.Entity.Base
{
    public class BaseEntity
    {

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 新增人
        /// </summary>
        public string CreateUser_Id { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string UpdateUser_Id { get; set; }

        /// <summary>
        /// 删除标记 0：未删除 1 已删除
        /// </summary>
        public DeleteFlg DeleteFlg { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }


    }
}
