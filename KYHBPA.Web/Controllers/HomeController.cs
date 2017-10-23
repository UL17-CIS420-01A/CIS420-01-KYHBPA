using KYHBPA.Web.Models;
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

            var carouselImageStrings = Db.Photos.Select(c => c.Content).Take(5).ToList();

            var newsImageBytes = Db.Photos.OrderBy(o => o.Uploaded).FirstOrDefault()?.Content;
            var eventsImageBytes = Db.Photos.OrderBy(o => o.Uploaded).FirstOrDefault()?.Content;
            var legislationImageBytes = Db.Photos.OrderBy(o => o.Uploaded).FirstOrDefault()?.Content;

            var viewModel = new HomepageViewModel()
            {
                CarouselBytes = carouselImageStrings,
                NewsImage = newsImageBytes,
                EventsImage = eventsImageBytes,
                LegislationImage = legislationImageBytes
            };

            return View(viewModel);
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