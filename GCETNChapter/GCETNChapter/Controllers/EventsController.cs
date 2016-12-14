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


        // GET: Events
        public PartialViewResult GetEventPartial()
        {
            var eventsVo = new EventsVO()
            {
                EventID = 10001,
                CreatedBy = Session["username"].ToString(),
                StartDate = Convert.ToDateTime( DateTime.Now.ToShortDateString()),
                EndDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };

            return PartialView("Events/_AddEvents", eventsVo);
        }

        [HttpPost]
        public ActionResult AddEvents(EventsVO eventVo)
        {
            return View();
        }


        // GET: Event Expense Details
        public ActionResult AddEventExpenseDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEventExpenseDetails(EventExpenseDetailsVO eventExpVo)
        {
            return View();
        }


        // GET: Event Expense Details
        public ActionResult AddEventPaymentCollection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEventPaymentCollection(EventPaymentCollectionVO eventPaymentVo)
        {
            return View();
        }


        // GET: Event Expense Details
        public ActionResult EventGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EventGallery(EventGalleryVO eventGalleryVo)
        {
            return View();
        }
    }
}