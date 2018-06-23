using Gift;
using qqliwuwang.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qqliwuwang.Controllers
{
    /// <summary>
    /// 文章控制器 将文章内容显示给用户
    /// </summary>
    public class ArticleController : Controller
    {
        ArticleManage artBll = new ArticleManage();
        // GET: Article
        public ActionResult Index(int id = 0)
        {
            try
            {
                var model = artBll.GetArticleById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new Article());
            }
        }

        /// <summary>
        /// 文章内容
        /// </summary>
        /// <returns></returns>
        public ActionResult Content(int id = 4028)
        {
            try
            {
                var model = artBll.GetArticleById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new Article());
            }
            return View();
        }
    }
}