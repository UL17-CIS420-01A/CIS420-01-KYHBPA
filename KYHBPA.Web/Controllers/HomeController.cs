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

            var carouselImageIds = Db.Photos.Select(c => c.Id).Take(5).ToList();

            var newsImageId = Db.Photos.OrderBy(o => o.Uploaded).Select(o=>o.Id).FirstOrDefault();
            var eventsImageId = Db.Photos.OrderBy(o => o.Uploaded).Select(o => o.Id).FirstOrDefault();
            var legislationImageId = Db.Photos.OrderBy(o => o.Uploaded).Select(o => o.Id).FirstOrDefault();

            var viewModel = new HomepageViewModel()
            {
                CarouselIds = carouselImageIds,
                NewsImageId = newsImageId,
                EventsImageId = eventsImageId,
                LegislationImageId = legislationImageId
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