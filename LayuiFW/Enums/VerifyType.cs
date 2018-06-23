using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Enums
{
    public enum VerifyType
    {

        /// <summary>
        /// 必填项
        /// </summary>
        Required,
        /// <summary>
        /// 手机号
        /// </summary>
        Phone,
        /// <summary>
        /// 邮箱
        /// </summary>
        Email,
        /// <summary>
        /// 网址
        /// </summary>
        Url,
        /// <summary>
        /// 数字
        /// </summary>
        Number,
        /// <summary>
        /// 日期
        /// </summary>
        Date,
        /// <summary>
        /// 身份证
        /// </summary>
        Identity
        //自定义值
    }
}
