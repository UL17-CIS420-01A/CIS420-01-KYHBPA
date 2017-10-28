using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KYHBPA.Controllers
{
    public class DocumentsController : BaseController
    {
        // GET: Documents
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListDocuments()
        {
            List<DocumentModel> documents = new List<DocumentModel>();

            return View(documents);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}