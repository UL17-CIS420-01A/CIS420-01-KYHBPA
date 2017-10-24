using KYHBPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Data.Repository;
using Microsoft.Practices.Unity;

namespace KYHBPA.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPhotoRepository _photoRepository =
            UnityConfig.GetConfiguredContainer().Resolve<IPhotoRepository>();

        public ActionResult Index()
        {

            var carouselImageIds = Db.Photos.Take(5).Select(c => c.Id).ToList();

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