using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Data.Infrastructure;
using KYHBPA.Data.Entity;

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
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult BoardofDirectors()
        {
            return View();
        }

        public ActionResult Membership()
        {
            return View();
        }
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Legislation()
        {
            return View();
        }

    }
}