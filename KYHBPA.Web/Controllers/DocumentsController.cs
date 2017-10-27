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

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Documents"), fileName);
                    file.SaveAs(path);
                }
                ViewBag.Message = "Success";
                return View();
            }
            catch
            {
                ViewBag.Message = "Failure";
                return View();
            }
        }

    }
}