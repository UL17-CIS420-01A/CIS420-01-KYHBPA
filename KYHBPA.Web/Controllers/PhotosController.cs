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
using KYHBPA.Repository;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using static System.Drawing.Image;

namespace KYHBPA.Controllers
{
    public class PhotosController : BaseController
    {
        private readonly IPhotoRepository _photoRepository =
            UnityConfig.GetConfiguredContainer().Resolve<IPhotoRepository>();

        // GET: Photos
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            PhotoGalleryViewModel result = new PhotoGalleryViewModel()
            {
                CurrentUser = User,
                Ids = await _photoRepository.FindPhotoGalleryIdsAsync()
            };
            return View(result);
        }

        // GET: Photos/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = await _photoRepository.FindByIdAsync(id.Value);
            if (photo.IsNull())
            {
                return HttpNotFound();
            }
            //var model = new PhotoDetailedViewModel()
            //{
            //    Id = photo.Id,
            //    IsDeleted = photo.IsDeleted,
            //    LastModified = photo.LastModified,
            //    Uploaded = photo.Uploaded,
            //    DeletedBy = photo.DeletedBy,
            //    LastModifiedBy = photo.LastModifiedBy,
            //    Deleted = photo.Deleted,
            //    IsInGallery = photo.IsInGallery,
            //    Description = photo.Description,
            //    PhotoCollectionKey = photo.PhotoCollectionKey,
            //    PhotoName = photo.PhotoName,
            //    UploadedBy = photo.UploadedBy,
            //};
            var model = AutoMapper.Mapper.Map(photo, new PhotoDetailedViewModel());

            return View(model);
        }

        // GET: Photos/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var viewModel = new PhotoUploadViewModel()
            {
                PhotoKeys = new[] { new SelectListItem() { Value = null, Text = "None", Selected = true } }.Concat((await _photoRepository.FindAvailableCollectionKeysAsync()).Select(o => new SelectListItem() { Value = o, Text = o })),
            };
            return View(viewModel);
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PhotoUploadViewModel photoUpload)
        {
            byte[] imageContent = null;
            if (photoUpload.ImageData.IsNull())
            {
                ModelState.AddModelError("ImageData", "You must select an image to upload.");
            }
            else if ((imageContent = photoUpload.ImageData.InputStream.ToImageContent()).IsNull())
            {
                ModelState.AddModelError("ImageData", "The file you uploaded is not an acceptable type of image.");
            }

            if (ModelState.IsValid)
            {
                var photo = new Photo
                {
                    Content = imageContent,
                    ContentLength = photoUpload.ImageData.ContentLength,
                    ContentType = photoUpload.ImageData.ContentType,
                    PhotoName = photoUpload.PhotoName,
                    Description = photoUpload.Description,
                    UploadedBy = User?.Member,
                    Uploaded = DateTime.UtcNow,
                    PhotoCollectionKey = photoUpload.PhotoCollectionKey,
                    IsInGallery = photoUpload.IsInGallery,

                };
                _photoRepository.Create(photo);
                return RedirectToAction(nameof(Index));
            }

            return View(photoUpload);
        }

        // GET: Photos/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = await _photoRepository.FindByIdAsync(id.Value);
            if (photo.IsNull())
            {
                return HttpNotFound();
            }
            var model = AutoMapper.Mapper.Map(photo, new PhotoEditViewModel());
            model.PhotoKeys = new[] { new SelectListItem() { Value = null, Text = "None", Selected = photo.PhotoCollectionKey.IsNullOrWhiteSpace() } }.Concat(
                (await _photoRepository.FindAvailableCollectionKeysAsync()).Select(o =>
                    new SelectListItem() { Value = o, Text = o, Selected = (photo.PhotoCollectionKey == o) }));
            return View(model);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PhotoEditViewModel photoEditViewModel)
        {
            if (photoEditViewModel.IsNull())
                return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
            {
                Photo photo = await _photoRepository.FindByIdAsync(photoEditViewModel.Id);
                photo = AutoMapper.Mapper.Map(photoEditViewModel, photo);
                photo.LastModifiedBy = User?.Member;
                photo.LastModified = DateTime.UtcNow;
                await _photoRepository.UpdateAsync(photo);
                return RedirectToAction(nameof(Index));
            }
            return View(photoEditViewModel);
        }

        // GET: Photos/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = _photoRepository.FindById(id.Value);
            if (photo.IsNull())
            {
                return HttpNotFound();
            }
            var model = AutoMapper.Mapper.Map(photo, new PhotoDetailedViewModel());

            return View(model);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid? id)
        {
            if (id.HasValue)
            {
                Photo photo = Db.Photos.FirstOrDefault(o => o.Id == id);
                photo.DeletedBy = User?.Member;
                _photoRepository.Delete(photo);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
