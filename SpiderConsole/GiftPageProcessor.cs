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
* 类 名 称 ：GiftPageProcessor
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：SpiderConsole
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/13 21:17:11
* 更新时间 ：2018/6/13 21:17:11
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace SpiderConsole
{
    /// <summary>
    /// 处理Page页面
    /// </summary>
    public class GiftPageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            //  var result = page.Selectable.XPath("//div[@class='content']");
            var result = page.Selectable.XPath("//div[@class='post-content']");

            var pid = page.Url.Substring(page.Url.LastIndexOf("/") + 1);
            //内容
            var content = result.XPath("//div[@class='content']");
            //标题
            var title = result.XPath("//h1");
            //主图URL
            var image = result.XPath("//div[@class='cover']").Css("img", "src");

            page.AddResultItem("pid", pid);
            page.AddResultItem("image", image.GetValue());
            page.AddResultItem("title", title.GetValue());
            page.AddResultItem("content", content.GetValue());
            //page.AddResultItem("key", result.GetValue());

        }
    }

    public class GiftPipeliner : BasePipeline
    {
        /// <summary>
        /// 数据处理 (保存到sql)
        /// </summary>
        /// <param name="resultItems"></param>
        /// <param name="spider"></param>
        public override void Process(IEnumerable<ResultItems> resultItems, ISpider spider)
        {

            var list = new List<Article>();
            foreach (var item in resultItems)
            {
                var model = new Article
                {
                    Type = "1",
                    Remark = "礼物说",
                    CreateTime = DateTime.Now,
                    PID = item.GetResultItem("pid"),
                    ContentHtml = item.GetResultItem("content"),
                    Title = item.GetResultItem("title"),
                    Image = item.GetResultItem("image")
                };
                list.Add(model);
            }

            foreach (var item in list)
            {
                GiftDB.GetInstance().Insert(item);
            }

        }
    }
}
