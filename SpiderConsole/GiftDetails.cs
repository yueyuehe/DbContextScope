using DotnetSpider.Core.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetSpider.Core;
using DotnetSpider.Core.Pipeline;
using qqliwuwang;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SpiderConsole
* 项目描述 ：
* 类 名 称 ：GiftDetails
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：SpiderConsole
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/13 23:13:41
* 更新时间 ：2018/6/13 23:13:41
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace SpiderConsole
{
    public class GiftDetailsPageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            var result = new { code = "", data = new { items = new List<ArticleDetail>() }, message = "" };
            var data = page.Content;
            var resultData = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(data, result);


            page.AddResultItem("key", resultData.data.items);
        }
    }
    public class GiftDetailsPipeliner : BasePipeline
    {
        public override void Process(IEnumerable<ResultItems> resultItems, ISpider spider)
        {
            var list = new List<ArticleDetail>();
            foreach (var item in resultItems)
            {
                list = (List<ArticleDetail>)item.Results["key"];

            }
            if (list.Count == 0)
            {
                Console.WriteLine("****************************************可能已经结束 ****************************************");
            }
            foreach (var item in list)
            {
                var db = GiftDB.GetInstance();
                item.PID = item.id.ToString();
                item.id = 0;
                db.Insert(item);
            }
        }
    }
}
