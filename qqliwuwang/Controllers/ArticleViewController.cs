﻿using Gift;
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
    public class ArticleViewController : Controller
    {
        ArticleManage artBll = new ArticleManage();
        // GET: Article
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var model = artBll.FindById(id.Value);
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new Gift_Article());
            }
        }

        /// <summary>
        /// 文章内容
        /// </summary>
        /// <returns></returns>
        public ActionResult Content(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var model = artBll.FindById(id.Value);
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new Gift_Article());
            }
        }
    }
}