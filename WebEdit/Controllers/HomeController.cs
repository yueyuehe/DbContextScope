using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEdit.Models;

namespace WebEdit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ArticleModel model)
        {
            if (model.Id == 0)
            {
                model = model.GetbyId(1);
            }
            else
            {
                model = model.GetbyId(model.Id);
            }
            return View("ArticleEdit", model);
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