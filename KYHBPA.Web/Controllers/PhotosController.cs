using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Data.Infrastructure;
using KYHBPA.Web.ActionResults;
using KYHBPA.Web.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace KYHBPA.Web.Controllers
{
    public class PhotosController : BaseController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Photos
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await Db.Photos.ToListAsync());
        }

        // GET: Photos/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = Db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        [HttpGet]
        public ActionResult Create()
        {

            var uploadPhoto = new UploadPhotoViewModel();
            return View(uploadPhoto);
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ImageData,PhotoName,Description")] UploadPhotoViewModel uploadPhoto, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var photo = new Photo()
                {
                    Uploader = User?.Member,
                    Content = uploadPhoto.ImageData.InputStream.ToByteArray(),
                    PhotoName = uploadPhoto.PhotoName,
                    Description = uploadPhoto.Description,
                };

                Db.Photos.Add(photo);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(uploadPhoto);
        }

        // GET: Photos/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = Db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Content,PhotoName,Description")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(photo).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = Db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Photo photo = Db.Photos.Find(id);
            Db.Photos.Remove(photo);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RenderImage(int id)
        {
            string contentType = "image/jpeg";
            Photo photo = Db.Photos.Find(id);
            if (photo.Content.IsNull() || photo.Content.ToConcatenatedString().IsNullOrWhiteSpace())
            {
                return new HttpNotFoundResult();
            }
            return Image(photo.Content, contentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ImageResult Image(Stream imageStream, string contentType)
        //{
        //    return new ImageResult(imageStream, contentType);
        //}

        public ImageResult Image(byte[] imageBytes, string contentType)
        {
            return new ImageResult(new MemoryStream(imageBytes), contentType);
        }
    }
}
