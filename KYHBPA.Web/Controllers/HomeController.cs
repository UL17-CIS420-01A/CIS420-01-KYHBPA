using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KYHBPA.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            //var imageStrings = Db.Photos.Where(photo => photo.Description.ToLower().Contains("carousel")).Select(s => s.Content).ToList();
            var imageStrings = Db.Photos.Select(c => c.Content).Take(5).ToList();

            return View(imageStrings);
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