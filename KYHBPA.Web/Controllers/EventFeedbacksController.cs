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
    public class EventFeedbacksController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventFeedbacks
        public async Task<ActionResult> Index()
        {
            return View(await db.EventFeedbacks.ToListAsync());
        }

        // GET: EventFeedbacks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventFeedback eventFeedback = await db.EventFeedbacks.FindAsync(id);
            if (eventFeedback == null)
            {
                return HttpNotFound();
            }
            return View(eventFeedback);
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
                EventFeedback obj = new EventFeedback()
                { Member=User?.Member, Event=null, Comments=eventFeedback.Comments };
           
                db.EventFeedbacks.Add(obj);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eventFeedback);
        }

        // GET: EventFeedbacks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventFeedback eventFeedback = await db.EventFeedbacks.FindAsync(id);
            if (eventFeedback == null)
            {
                return HttpNotFound();
            }
            EventFeedbackViewModel obj = new EventFeedbackViewModel()
            {Id= eventFeedback.Id, Member = eventFeedback.Member, Event = eventFeedback.Event, Comments = eventFeedback.Comments };
            
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
                db.Entry(eventFeedback).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eventFeedback);
        }

        // GET: EventFeedbacks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventFeedback eventFeedback = await db.EventFeedbacks.FindAsync(id);
            if (eventFeedback == null)
            {
                return HttpNotFound();
            }
            return View(eventFeedback);
        }

        // POST: EventFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EventFeedback eventFeedback = await db.EventFeedbacks.FindAsync(id);
            db.EventFeedbacks.Remove(eventFeedback);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
