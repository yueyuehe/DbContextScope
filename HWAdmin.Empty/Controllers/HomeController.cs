using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HWAdmin.Empty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(DateTime dt)
        {
            ViewData["DT"] = dt.ToLongTimeString();
            return View();
        }
    }
}