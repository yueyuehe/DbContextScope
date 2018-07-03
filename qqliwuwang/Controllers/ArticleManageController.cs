using Common.Model;
using Gift;
using qqliwuwang.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qqliwuwang.Controllers
{
    public class ArticleManageController : Controller
    {
        ArticleManage artBll = new ArticleManage();
      
        /// <summary>
        /// 转到文章详情页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Article(int id = 4028)
        {
            try
            {
                var model = artBll.FindById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new Gift_Article());
            }
        }

        /// <summary>
        ///  文章列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ArticleList()
        {
            Qq_Article model = new Qq_Article();
            return View(model);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pageModel"></param>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public ActionResult Articles(BsPageRequest pageModel, Qq_Article queryModel)
        {
            var page = artBll.Page(pageModel.PageNum, pageModel.Limit, queryModel, pageModel.Sort, pageModel.Order);
            BsPageResponse resData = new BsPageResponse();
            resData.rows = page.Items;
            resData.total = page.TotalItems;
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = resData;
            return result;
        }

    }
}