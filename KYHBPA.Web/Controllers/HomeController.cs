using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Data.Infrastructure;

namespace KYHBPA.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page."; // ((User?.Email) ?? "NULL") + " | " + ((User?.Member) == null) + " | " + ((User?.Member?.FullName) ?? "NULL");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}