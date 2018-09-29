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
    public class HomeController : Controller
    {
        ArticleManage artBll = new ArticleManage();
        public ActionResult Index(PetaPoco.Page<Qq_Article> page, Qq_Article queryModel)
        {
            if (page.ItemsPerPage == 0)
            {
                page.ItemsPerPage = 20;
            }
            if (page.CurrentPage == 0)
            {
                page.CurrentPage = 1;
            }
            page = artBll.Page(page.CurrentPage, page.ItemsPerPage, queryModel, nameof(queryModel.PublicTime), "DESC");
            return View(page);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}