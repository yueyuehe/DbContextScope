﻿using Gift;
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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Article(int id = 4028)
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