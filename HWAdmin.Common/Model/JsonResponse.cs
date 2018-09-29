using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HWAdmin.Common.Model
* 项目描述 ：
* 类 名 称 ：JsonResponse
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：HWAdmin.Common.Model
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/8/7 21:25:22
* 更新时间 ：2018/8/7 21:25:22
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace HWAdmin.Common.Model
{
    /// <summary>
    /// webAPI的json数据模型
    /// </summary>
    public class JsonResponse
    {
        public JsonResponse()
        {
            Encoding = Encoding.UTF8;
            MediaType = "application/json";
        }
        public System.Text.Encoding Encoding { get; set; }
        public object Data { get; set; }

        public string MediaType { get; set; }

        public System.Net.Http.HttpResponseMessage ToHttpResponse()
        {
            var rep = new System.Net.Http.HttpResponseMessage
            {
                Content = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(Data), Encoding, MediaType)
            };
            return rep;
        }
    }
}
