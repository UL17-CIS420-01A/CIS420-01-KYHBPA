using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA.ActionResults;
using KYHBPA.Models;
using Microsoft.Ajax.Utilities;
using static System.Drawing.Image;

namespace KYHBPA.Controllers
{
    public class PhotosController : BaseController
    {

        // GET: Photos
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = new TaskFactory().StartNew(()=>Db.Photos.Include(o => o.UploadedBy).Include(o => o.Event).ToList()).Result;
            return View(result);
        }

        // GET: Photos/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id.IsNull())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = await Db.Photos.Include(o => o.UploadedBy).Include(o => o.Event).SingleOrDefaultAsync(o => o.Id == id);
            if (photo.IsNull())
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        [HttpGet]
        public ActionResult Create() => View(new UploadPhotoViewModel());

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "ImageData,PhotoName,Description")] UploadPhotoViewModel uploadPhoto, HttpPostedFileBase imageData)
        {
            byte[] imageContent = null;
            if (uploadPhoto.ImageData.IsNull())
            {
                ModelState.AddModelError("ImageData", "You must select an image to upload.");
            }
            else if ((imageContent = uploadPhoto.ImageData.InputStream.ToByteArray()).IsNull())
            {
                ModelState.AddModelError("ImageData", "The file you uploaded is not an acceptable type of image.");
            }


            if (ModelState.IsValid)
            {
                var photo = new Photo
                {
                    Content = imageContent,
                    ContentLength = uploadPhoto.ImageData.ContentLength,
                    ContentType = uploadPhoto.ImageData.ContentType,
                    PhotoName = uploadPhoto.PhotoName,
                    Description = uploadPhoto.Description,
                    UploadedBy = User?.Member,
                    Uploaded = DateTime.UtcNow,
                    LastModifiedBy = User?.Member,
                    LastModified = DateTime.UtcNow
                };
                Db.Photos.Add(photo);
                await Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(uploadPhoto);
        }

        // GET: Photos/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id.IsNull())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = await Db.Photos.Include(o => o.UploadedBy).Include(o => o.Event).SingleOrDefaultAsync(o => o.Id == id);
            if (photo.IsNull())
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
        public async Task<ActionResult> Edit(Photo photo)
        {
            Photo p = await Db.Photos.Include(o => o.UploadedBy).Include(o => o.Event).SingleOrDefaultAsync(o => o.Id == photo.Id);
            if (p.IsNull())
                return RedirectToAction(nameof(Index));
            photo.Content = p.Content;
            photo.ContentLength = p.ContentLength;
            photo.ContentType = p.ContentType;
            photo.Event = p.Event;
            photo.UploadedBy = p.UploadedBy;
            photo.Uploaded = p.Uploaded;
            if (ModelState.IsValid)
            {
                photo.LastModifiedBy = User?.Member;
                photo.LastModified = DateTime.UtcNow;
                Db.Photos.AddOrUpdate((o) => o.Id, photo);
                await Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id.IsNull())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = await Db.Photos.Include(o => o.UploadedBy).Include(o => o.Event).SingleOrDefaultAsync(o => o.Id == id);
            if (photo.IsNull())
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid? id)
        {
            Photo photo = await Db.Photos.FirstOrDefaultAsync(o => o.Id == id);
            if (ModelState.IsValid)
            {
                photo.DeletedBy = User?.Member;
                photo.Deleted = DateTime.UtcNow;
                Db.Entry(photo).State = EntityState.Modified;
                await Db.SaveChangesAsync();
            }
            Db.Photos.Remove(photo);
            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
