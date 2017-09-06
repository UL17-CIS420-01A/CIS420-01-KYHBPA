using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KYHBPA.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message="Your done goofed Louis!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message="This might be your contact page. What do you think?";

            return View();
        }
    }
}