using HWAdmin.Common.Model;
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
        public ActionResult Article(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ArticleList");
                }
                var model = artBll.FindById(id.Value);
                var Category = new SysConfigBLL().GetArticleCategorys();
                ViewData["Category"] = Category;
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new Qq_Article());
            }
        }

        /// <summary>
        ///  转到文章列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ArticleList()
        {
            Qq_Article model = new Qq_Article();
            return View(model);
        }

        /// <summary>
        /// 获取文章列表数据
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

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Qq_Article model)
        {
            model.Category = Request["Category"];
            if (model.IsNew())
            {
                model.UpdateTime = DateTime.Now;
                model.Created = DateTime.Now;
                model.CreateTime = DateTime.Now;
                model.CreateUser = Helper.CommonHelper.LoginUser().Id;
                model.UpdateUser = Helper.CommonHelper.LoginUser().Id;
                model.DeleteFlag = Helper.DeleteFlag.NO.ToString();
                model.Insert();
            }
            else
            {
                var oldModel = artBll.FindById(model.Id);
                oldModel.Title = model.Title;
                oldModel.Excerpt = model.Excerpt;
                oldModel.HeadContent = model.HeadContent;
                oldModel.Author = model.Author;
                oldModel.Category = model.Category;
                oldModel.IsDisplay = model.IsDisplay;
                oldModel.IsDigest = model.IsDigest;
                oldModel.Source = model.Source;
                oldModel.PublicTime = model.PublicTime;
                oldModel.Keyword = model.Keyword;
                oldModel.UpdateTime = DateTime.Now;
                oldModel.UpdateUser = Helper.CommonHelper.LoginUser().Id;
                oldModel.Update();
            }
            return RedirectToAction("ArticleList");
        }
    }
}