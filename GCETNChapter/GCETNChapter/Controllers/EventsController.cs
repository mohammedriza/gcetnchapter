using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Events()
        {
            return View();
        }

        // GET: View All Events
        public PartialViewResult ViewEvents()
        {
            var response = new EventsDA().GetAllEvents(0);

            return PartialView("Events/_ViewEvents", response);
        }

        // GET: Events
        public PartialViewResult AddEvent(int EventID = 0)
        {
            if (EventID <=0)
            {
                var eventsVo = new EventsVO()
                {
                    EventID = 0,
                    CreatedBy = Session["username"].ToString(),
                    StartDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    EndDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                };
                return PartialView("Events/_AddEvents", eventsVo);
            }
            else
            {
                var response = new EventsDA().GetAllEvents(EventID);
                var Event = new EventsVO()
                {
                    EventID = response.ElementAt(0).EventID,
                    EventName = response.ElementAt(0).EventName,
                    StartDate = response.ElementAt(0).StartDate,
                    EndDate = response.ElementAt(0).EndDate,
                    TotalCollectedAmount = Convert.ToDecimal(response.ElementAt(0).TotalCollectedAmount),
                    TotalExpenseAmount = Convert.ToDecimal(response.ElementAt(0).TotalExpenseAmount),
                    CreatedBy = response.ElementAt(0).CreatedBy,
                    CreatedDate = response.ElementAt(0).CreatedDate,
                    ModifiedBy = response.ElementAt(0).ModifiedBy,
                    ModifiedDate = response.ElementAt(0).ModifiedDate
                };
                return PartialView("Events/_AddEvents", Event);
            }
        }

        [HttpPost]  // POST: Add Events
        public bool AddEvents(EventsVO eventVo)
        {
            eventVo.CreatedBy = Session["username"].ToString();

            var result = new EventsDA().AddNewEventDetail(eventVo);

            if (result >= 1)
                return true;
            else
                return false;
        }


        // GET: Event Expense Details
        public PartialViewResult AddEventExpenseDetails()
        {
            var eventExpVo = new EventExpenseDetailsVO();
            return PartialView("Events/_AddEventExpenseDetails", eventExpVo);
        }

        [HttpPost]  // POST: Event Expense Details
        public ActionResult AddEventExpenseDetails(EventExpenseDetailsVO eventExpVo)
        {
            return View();
        }


        // GET: Event Expense Details
        public PartialViewResult AddEventPaymentCollection()
        {
            var eventPaymentVo = new EventPaymentCollectionVO();
            return PartialView("Events/_AddEventPaymentCollection", eventPaymentVo);
        }

        [HttpPost]  // POST: Event Expense Details
        public ActionResult AddEventPaymentCollection(EventPaymentCollectionVO eventPaymentVo)
        {
            return View();
        }


        // GET: Event Expense Details
        public ActionResult EventGallery()
        {
            return View();
        }

        [HttpPost]  // POST: Event Expense Details
        public ActionResult EventGallery(EventGalleryVO eventGalleryVo)
        {
            return View();
        }
    }
}