using DotnetSpider.Core;
using qqliwuwang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SpiderConsole
* 项目描述 ：
* 类 名 称 ：SpiderMain
* 类 描 述 ：
* 所在的域 ：yueyuehe-PC
* 命名空间 ：SpiderConsole
* 机器名称 ：YUEYUEHE-PC 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：yueyuehe
* 创建时间 ：2018/6/13 21:06:43
* 更新时间 ：2018/6/13 21:06:43
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ yueyuehe 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
namespace SpiderConsole
{
    public class SpiderMain
    {
        public void SatrtSpider()
        {
            List<Request> resList = new List<Request>();
            var site = new DotnetSpider.Core.Site() { EncodingName = "UTF-8" };
            site.CycleRetryTimes = 1;
            //循环获取29页句子迷原创句子  
            var db = GiftDB.GetInstance();
            var list = db.Query<ArticleDetail>("SELECT * FROM t_gift_ArticleDetails");
            foreach (var item in list)
            {
                //var url = $"http://www.liwushuo.com/posts/{item.PID}/content";
                var url = $"http://www.liwushuo.com/posts/{item.PID}";

                site.AddStartUrl(url);
            }
            var spider = Spider.Create(site, new GiftPageProcessor())
                .AddStartRequests(resList.ToArray())
                .AddPipeline(new GiftPipeliner());
            spider.ThreadNum = 1;
            spider.Run();
        }
    }
}
