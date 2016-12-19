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

        public bool CheckIfValidCollegeRegNo(string CollegeRegNo)
        {
            var result = MemberDA.CheckIfCollegeRegNoExist(CollegeRegNo);

            if (string.IsNullOrEmpty(result))
                return false;
            else
                return true;
        }

        //%%%%%%%%%%%%%%%%%%% MANAGE EVENTS %%%%%%%%%%%%%%%%%%%//

        // GET: View All Events
        public PartialViewResult ViewEvents()
        {
            var response = new EventsDA().GetAllEvents(0);

            return PartialView("Events/_ViewEvents", response);
        }

        // GET: Events
        public PartialViewResult GetEventDetailsByEventID(int EventID = 0)
        {
            if (EventID <=0)
            {
                var eventsVo = new EventsVO()
                {
                    CreatedBy = Session["username"].ToString()
                };
                return PartialView("Events/_AddEvents", eventsVo);
            }
            else
            {
                var response = new EventsDA().GetEventByEventID(EventID);
                return PartialView("Events/_AddEvents", response);
            }
        }

        [HttpPost]  // POST: Add Events
        public bool AddNewEvent(EventsVO eventVo)
        {
            eventVo.CreatedBy = Session["username"].ToString();

            var result = new EventsDA().AddUpdateEventDetail(eventVo);

            if (result >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool DeleteEvent(int EventID)
        {
            try
            {
                var result = new EventsDA().DeleteEvent(EventID);

                if (result >= 1)
                    return true;
                else
                    return false;
            }
            catch(Exception)
            {
                return false;
            }
        }


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT PAYMENT COLLECTIONS %%%%%%%%%%%%%%%%%%%//
        
        // GET: View All Events
        public PartialViewResult GetAllEventPaymentCollections(int PaymentCollectionID)
        {
            var response = new EventsDA().GetAllEventPaymentCollections(PaymentCollectionID);
            return PartialView("Events/_ViewEventPaymentCollection", response);
        }


        // GET: Events
        public PartialViewResult GetEventPaymentCollectionByID(int PaymentCollectionID = 0, int EventID = 0)
        {
            if (PaymentCollectionID <= 0)
            {
                var paymentsVo = new EventPaymentCollectionVO()
                {
                    CreatedBy = Session["username"].ToString(),
                    EventID = EventID
                };
                return PartialView("Events/_AddEventPaymentCollection", paymentsVo);
            }
            else
            {
                var response = new EventsDA().GetEventPaymentCollectionByID(PaymentCollectionID);
                return PartialView("Events/_AddEventPaymentCollection", response);
            }
        }


        [HttpPost]  // POST: Event Expense Details
        public bool AddEventPaymentCollection(EventPaymentCollectionVO eventPaymentVo)
        {
            eventPaymentVo.CreatedBy = Session["username"].ToString();
            var CollegeRegNoExist = MemberDA.CheckIfCollegeRegNoExist(eventPaymentVo.CollegeRegistrationNo);

            if (string.IsNullOrEmpty(CollegeRegNoExist))
                return false;
            else
            {
                var result = new EventsDA().AddUpdateEventPaymentCollection(eventPaymentVo);

                if (result >= 1)
                    return true;
                else
                    return false;
            }
        }

        [HttpPost]
        public bool DeleteEventPaymentCollection(int PaymentCollectionID)
        {
            try
            {
                var result = new EventsDA().DeleteEventPaymentCollection(PaymentCollectionID);

                if (result >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT EXPENSE DETAILS %%%%%%%%%%%%%%%%%%%//

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


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT GALLERY %%%%%%%%%%%%%%%%%%%//

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