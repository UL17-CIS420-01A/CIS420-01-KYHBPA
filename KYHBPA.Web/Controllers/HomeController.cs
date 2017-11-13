using KYHBPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Repository;
using Microsoft.Practices.Unity;

namespace KYHBPA.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPhotoRepository _photoRepository =
            UnityConfig.GetConfiguredContainer().Resolve<IPhotoRepository>();

        public ActionResult Index()
        {

            var carouselImageIds = _photoRepository.FindPhotoIdsByKey("Carousel").ToList();
            var newsImageId = _photoRepository.FindPhotoIdByKey("News");
            var eventsImageId = _photoRepository.FindPhotoIdByKey("Events");

            var viewModel = new HomepageViewModel()
            {
                CarouselIds = carouselImageIds,
                NewsImageId = newsImageId,
                EventsImageId = eventsImageId,
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