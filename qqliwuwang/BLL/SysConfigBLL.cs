using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace qqliwuwang.BLL
{
    public class SysConfigBLL
    {
        public string filePath = "App_Data/Config/ArticleCategory.xml";
        public XmlDocument Document()
        {
            var rootPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            XmlDocument xml = new XmlDocument();
            xml.Load(System.IO.Path.Combine(rootPath, filePath));
            return xml;
        }

        /// <summary>
        /// 获取文章分类
        /// </summary>
        /// <returns></returns>
        public List<ArticleCategory> GetArticleCategorys()
        {
            var categotyList = Document().SelectNodes("/config/ArticleCategoty/Categoty");
            List<ArticleCategory> list = new List<ArticleCategory>();
            foreach (XmlNode item in categotyList)
            {
                ArticleCategory model = new ArticleCategory();
                model.CategotyName = item.Attributes.GetNamedItem("value").Value;
                var items = item.SelectNodes("group");
                var CategoryList = new List<Category>();
                foreach (XmlNode temp in items)
                {
                    Category tempModel = new Category();
                    tempModel.GroupName = temp.Attributes.GetNamedItem("value").Value;
                    foreach (XmlNode groupItem in temp.SelectNodes("item"))
                    {
                        tempModel.Items.Add(groupItem.Attributes.GetNamedItem("key").Value, groupItem.Attributes.GetNamedItem("value").Value);
                    }
                    CategoryList.Add(tempModel);
                }
                model.Categoties = CategoryList;
                list.Add(model);
            }
            return list;
        }


    }


    public enum ArticleCategoty
    {
        /// <summary>
        /// 人群画像
        /// </summary>
        Crowd,
        /// <summary>
        /// 目的
        /// </summary>
        Purpose,
        /// <summary>
        /// 节日
        /// </summary>
        Festival

    }


    public class ArticleCategory
    {
        public string CategotyName { get; set; }

        public List<Category> Categoties { get; set; }

    }


    public class Category
    {
        public Category()
        {
            Items = new Dictionary<string, string>();
        }
        public string GroupName { get; set; }

        public Dictionary<string, string> Items { get; set; }

    }

}