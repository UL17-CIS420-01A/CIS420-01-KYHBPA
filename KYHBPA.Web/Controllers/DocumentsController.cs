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

namespace KYHBPA.Controllers
{
    public class DocumentsController : BaseController
    {
        private readonly IDocumentRepository _documentRepository =
            UnityConfig.GetConfiguredContainer().Resolve<IDocumentRepository>();

        //GET: Documents
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            DocumentsListViewModel result = new DocumentsListViewModel()
            {
                CurrentUser = User,
                Ids = await _documentRepository.FindDocumentListIdsAsync()
            };
            return View(result);
        }

        //GET: Documents/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = await _documentRepository.FindByIdAsync(id.Value);
            if (document.IsNull())
            {
                return HttpNotFound();
            }

            var model = AutoMapper.Mapper.Map(document, new DocumentDetailedViewModel());

            return View(model);
        }

        //GET: Documents/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var viewModel = new DocumentUploadViewModel()
            {
                DocumentKeys = new[] { new SelectListItem() { Value = null, Text = "None", Selected = true } }.Concat((await _documentRepository.FindAvailableCollectionKeysAsync()).Select(o => new SelectListItem() { Value = o, Text = o })),
            };
            return View(viewModel);
        }

        //POST: Document/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DocumentUploadViewModel documentUpload)
        {
            //no ImageData for document. what do I use instead?
        }*/

        //GET: Document/Edit/5
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = await _documentRepository.FindByIdAsync(id.Value);
            if (document.IsNull())
            {
                return HttpNotFound();
            }
            var model = AutoMapper.Mapper.Map(document, new DocumentEditViewModel());
            model.DocumentKeys = new[] { new SelectListItem() { Value = null, Text = "None", Selected = document.DocumentCollectionKey.IsNullOrWhiteSpace() } }.Concat(
                (await _documentRepository.FindAvailableCollectionKeysAsync()).Select(o =>
                    new SelectListItem() { Value = o, Text = o, Selected = (document.DocumentCollectionKey == o) }));
            return View(model);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Edit(DocumentEditViewModel documentEditViewModel)
        {
            if (documentEditViewModel.IsNull())
                return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
            {
                Document document = await _documentRepository.FindByIdAsync(documentEditViewModel.Id);
                document = AutoMapper.Mapper.Map(documentEditViewModel, document);
                document.LastModifiedBy = User?.Member;
                document.LastModified = DateTime.UtcNow;
                await _documentRepository.UpdateAsync(document);
                return RedirectToAction(nameof(Index));
            }
            return View(documentEditViewModel);
        }

        // GET: Document/Delete/5
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = _documentRepository.FindById(id.Value);
            if (document.IsNull())
            {
                return HttpNotFound();
            }
            var model = AutoMapper.Mapper.Map(document, new DocumentDetailedViewModel());

            return View(model);
        }

        // Post: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteConfirmed(Guid? id)
        {
            if (id.HasValue)
            {
                Document document = Db.Documents.FirstOrDefault(o => o.Id == id);
                document.DeletedBy = User?.Member;
                _documentRepository.Delete(document);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}   