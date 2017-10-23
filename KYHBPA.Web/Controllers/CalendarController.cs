//using System.Linq;
//using System.Net;
//using System.Web.Mvc;
//using KYHBPA.Models;
//using EventClickArgs = KYHBPA.Mvc.Events.Month.EventClickArgs;
//using EventMoveArgs = KYHBPA.Mvc.Events.Month.EventMoveArgs;
//using InitArgs = KYHBPA.Mvc.Events.Month.InitArgs;
//using TimeRangeSelectedArgs = KYHBPA.Mvc.Events.Month.TimeRangeSelectedArgs;

//namespace KYHBPA.Controllers
//{
//    public class CalendarController : BaseController
//    //{
//        private readonly ApplicationDbContext _db = new ApplicationDbContext();

//        // GET: Calendar
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult Backend()
//        {
//            return new Dpm().CallBack(this);
//        }

//        public ActionResult Edit(string id, string titleText)
//        {

//            var eventToModify = _db.Events.FirstOrDefault(ev => ev.id.ToString() == id);

//            eventToModify.text = titleText;
//            _db.SaveChanges();

//            return new HttpStatusCodeResult(HttpStatusCode.OK);
//            //return new Dpm().CallBack(this);
//        }
//    }


//    public class Dpm : DayPilotMonth
//    {
//        private readonly ApplicationDbContext _db = new ApplicationDbContext();
//        protected override void OnInit(InitArgs e)
//        {
//            Events = from ev in _db.Events where !((ev.end_date <= VisibleStart) || (ev.start_date >= VisibleEnd)) select ev;

//            DataIdField = "id";
//            DataTextField = "text";
//            DataStartField = "start_date";
//            DataEndField = "end_date";

//            Update();
//        }

//        protected override void OnFinish()
//        {
//            if (UpdateType == CallBackUpdateType.None)
//            {
//                return;
//            }

//            DataIdField = "id";
//            DataStartField = "start_date";
//            DataEndField = "end_date";
//            DataTextField = "text";


//            Events = from e in _db.Events where !((e.end_date <= VisibleStart) || (e.start_date >= VisibleEnd)) select e;
//        }


//        protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
//        {
//            if (string.IsNullOrEmpty((string)e.Data["name"]))
//            {
//                return;
//            }

//            var createdEvent = new Event()
//            {
//                text = (string)e.Data["name"],
//                start_date = e.Start,
//                end_date = e.End
//            };

//            _db.Events.Add(createdEvent);

//            _db.SaveChanges();

//            Update();
//        }

//        protected override void OnEventMove(EventMoveArgs e)
//        {
//            var dbEvent = _db.Events.FirstOrDefault(ev => ev.id.ToString() == e.Id);

//            if (dbEvent != null)
//            {

//                dbEvent.start_date = e.NewStart;
//                dbEvent.end_date = e.NewEnd;

//                _db.SaveChanges();
//            }

//            Update();
//        }

//        protected override void OnEventClick(EventClickArgs e)
//        {
//            if (string.IsNullOrEmpty(e.Text))
//            {
//                return;
//            }

//            var dbEvent = _db.Events.FirstOrDefault(ev => ev.id.ToString() == e.Id);

//            if (dbEvent != null)
//            {
//                dbEvent.text = e.Text;
//                dbEvent.start_date = e.Start;
//                dbEvent.end_date = e.End;

//                _db.SaveChanges();
//            }

//            Update();
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;
using KYHBPA.Models;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using KYHBPA;
using KYHBPA.Data.Infrastructure;

namespace KYHBPA.Controllers
{
    public class EventController : BaseController
    {
        //Refer to this link in order to set up the Calendar.
        //http://scheduler-net.com/docs/simple-.net-mvc-application-with-scheduler.html#step_2_add_the_scheduler_reference

        

        public ActionResult Index()
        {
            //try { 
            var scheduler = new DHXScheduler(this); //initializes dhtmlxScheduler
            scheduler.LoadData = true;// allows loading data
            scheduler.EnableDataprocessor = true;// enables DataProcessor in order to enable implementation CRUD operations

            return View(scheduler);
            //}
            //catch (Exception ex)
            //{
            //    if (ex != null)
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }                
            //}

            //return RedirectToAction("Index", "Home");
           
        }

        public JsonResult Data()
        {
            //Using Dxhtml JavaScript Edition (open source)
            var events = Db.Events;

            var formatedEvents = new List<object>();
            foreach (var ev in events)
            {
                var formattingEvent = new
                {
                    id = ev.Id,
                    start_date = ev.StartDate.ToString(),
                    end_date = ev.EndDate.ToString(),
                    //start_date = ev.start_date.Date.ToString("yyyy-MM-dd"),
                    //end_date = ev.end_date.Date.ToString("yyyy-MM-dd"),
                    text = ev.Description
                };
                formatedEvents.Add(formattingEvent);
            }



            return Json(formatedEvents, JsonRequestBehavior.AllowGet);

            //Using Dxhtml MVC Scheduler Edition (free trial)
            //events for loading to scheduler
            //return new SchedulerAjaxData(_db.Events);
        }

        public ActionResult Save(string id, string text, string start_date, string end_date)
        {

            var existingEvent = Db.Events.FirstOrDefault(e => e.Id.ToString() == id);
            var newStartDate = Convert.ToDateTime(start_date);
            var newEndDate = Convert.ToDateTime(end_date);


            if (existingEvent != null)
            {
                existingEvent.StartDate = newStartDate;
                existingEvent.EndDate = newEndDate;
                existingEvent.Description = text;
            }
            else
            {

                var newEvent = new Event()
                {
                    StartDate = newStartDate,
                    EndDate = newEndDate,
                    Description = text
                };
                Db.Events.Add(newEvent);
            }

            Db.SaveChanges();



            return View("Index");
        }

        public ActionResult Delete(string id, string text, string start_date, string end_date)
        {

            var existingEvent = Db.Events.FirstOrDefault(e => e.Id.ToString() == id);
            var newStartDate = Convert.ToDateTime(start_date);
            var newEndDate = Convert.ToDateTime(end_date);

            if (existingEvent != null)
            {
                Db.Events.Remove(existingEvent);
                Db.SaveChanges();
            }

            return View("Index");
        }


        //public ActionResult Save(Event updatedEvent, FormCollection formData)
        //{
        //    var action = new DataAction(formData);

        //    try
        //    {
        //        switch (action.Type)
        //        {
        //            case DataActionTypes.Insert: // your Insert logic
        //                _db.Events.Add(updatedEvent);
        //                break;
        //            case DataActionTypes.Delete: // your Delete logic
        //                updatedEvent = _db.Events.SingleOrDefault(ev => ev.id == updatedEvent.id);
        //                _db.Events.Remove(updatedEvent);
        //                break;
        //            default:// "update" // your Update logic
        //                updatedEvent = _db.Events.SingleOrDefault(
        //                ev => ev.id == updatedEvent.id);
        //                UpdateModel(updatedEvent);
        //                break;
        //        }
        //        _db.SaveChanges();
        //        action.TargetId = updatedEvent.id;
        //    }
        //    catch (Exception e)
        //    {
        //        action.Type = DataActionTypes.Error;
        //    }
        //    return (new AjaxSaveResponse(action));
        //}
    }
}