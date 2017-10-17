using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA;
using KYHBPA.Web.Models;

namespace KYHBPA.Web.Controllers
{
    public class EventFeedbackController : BaseController
    {
        // GET: EventFeedbacks
        public async Task<ActionResult> Index()
        {
            return View(await Db.EventFeedback.Select(o => new EventFeedbackViewModel() { Id = o.Id, Event = o.Event, Member = o.Member, Comments = o.Comments }).ToListAsync());
        }

        // GET: EventFeedbacks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id.IsNull())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventFeedback eventFeedback = await Db.EventFeedback.FindAsync(id);
            if (eventFeedback.IsNull())
            {
                return HttpNotFound();
            }

            EventFeedbackViewModel model = new EventFeedbackViewModel()
            { Id = eventFeedback.Id, Member = eventFeedback.Member, Event = eventFeedback.Event, Comments = eventFeedback.Comments };

            return View(model);
        }

        // GET: EventFeedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Comments")] EventFeedbackViewModel eventFeedback)
        {
            if (ModelState.IsValid)
            {
                EventFeedback model = new EventFeedback()
                { Member = User?.Member, Event = null, Comments = eventFeedback.Comments };
                
                Db.EventFeedback.Add(model);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eventFeedback);
        }

        // GET: EventFeedbacks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id.IsNull())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventFeedback eventFeedback = await Db.EventFeedback.FindAsync(id);
            if (eventFeedback.IsNull())
            {
                return HttpNotFound();
            }
            EventFeedbackViewModel obj = new EventFeedbackViewModel()
            { Id = eventFeedback.Id, Member = eventFeedback.Member, Event = eventFeedback.Event, Comments = eventFeedback.Comments };

            return View(obj);
        }

        // POST: EventFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Comments")] EventFeedbackViewModel eventFeedback)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(eventFeedback).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eventFeedback);
        }

        // GET: EventFeedbacks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id.IsNull())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventFeedback eventFeedback = await Db.EventFeedback.FindAsync(id);
            if (eventFeedback.IsNull())
            {
                return HttpNotFound();
            }

            EventFeedbackViewModel model = new EventFeedbackViewModel()
            {
                Id = eventFeedback.Id,
                Event = eventFeedback.Event,
                Member = eventFeedback.Member,
                Comments = eventFeedback.Comments
            };

            return View(model);
        }

        // POST: EventFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EventFeedback eventFeedback = await Db.EventFeedback.FindAsync(id);
            if ((eventFeedback?.Id) != null)
            {
                Db.EventFeedback.Remove(eventFeedback);
                await Db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
