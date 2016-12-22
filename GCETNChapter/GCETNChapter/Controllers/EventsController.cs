﻿using GCETNChapter.Models.DataAccess;
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

        //-- Check if College Reg No exist and return FALSE is College Reg No doesnt exist, else return TRUE
        public bool CheckIfValidCollegeRegNo(string CollegeRegNo)
        {
            var result = MemberDA.CheckIfCollegeRegNoExist(CollegeRegNo);

            if (string.IsNullOrEmpty(result))
                return false;
            else
                return true;
        }

        //-- Check if Event Name exist and return FALSE is event name doesnt exist, else return TRUE
        public bool CheckIfEventNameExist(string EventName)
        {
            var result = EventsDA.CheckIfEventNameExist(EventName);

            if (string.IsNullOrEmpty(result))
                return false;
            else
                return true;
        }

        //--- Get Event ID when user selects an Event Name from the doprdown list ---//
        public int GetEventIdByEventName(string EventName)
        {
            var result = EventsDA.GetEventIDByEventName(EventName);
            return result;
        }


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENTS %%%%%%%%%%%%%%%%%%%//

        // GET: View All Events
        public PartialViewResult ViewEvents()
        {
            var response = new EventsDA().GetAllEvents(0);

            return PartialView("ManageEvents/_ViewEvents", response);
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
                return PartialView("ManageEvents/_AddEvents", eventsVo);
            }
            else
            {
                var response = new EventsDA().GetEventByEventID(EventID);
                return PartialView("ManageEvents/_AddEvents", response);
            }
        }

        [HttpPost]  // POST: Add Events
        public bool AddNewEvent(EventsVO eventVo)
        {
            var DuplicateEventName = "";
            if (eventVo.EventID <= 0)
            {
                //--- Check this only if the Event ID is 0, which means its a Add Event and not edit event ---//
                DuplicateEventName = EventsDA.CheckIfEventNameExist(eventVo.EventName);
            }

            if (!string.IsNullOrEmpty(DuplicateEventName))
            {
                return false;
            }
            else
            {
                eventVo.CreatedBy = Session["username"].ToString();

                var result = new EventsDA().AddUpdateEventDetail(eventVo);

                if (result >= 1)
                    return true;
                else
                    return false;
            }
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
            return PartialView("PaymentCollections/_ViewEventPaymentCollection", response);
        }


        // GET: Events
        public PartialViewResult GetEventPaymentCollectionByID(int PaymentCollectionID = 0, int EventID = 0)
        {
            if (PaymentCollectionID <= 0)
            {
                var paymentsVo = new EventPaymentCollectionVO()
                {
                    CreatedBy = Session["username"].ToString(),
                    EventID = EventID,
                    EventNameList = EventsDA.GetAllEventNames()
                };
                return PartialView("PaymentCollections/_AddEventPaymentCollection", paymentsVo);
            }
            else
            {
                var response = new EventsDA().GetEventPaymentCollectionByID(PaymentCollectionID);
                return PartialView("PaymentCollections/_AddEventPaymentCollection", response);
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

        // GET: View All Event Expense Details
        public PartialViewResult GetAllEventExpenseDetails(int ExpenseDetailID)
        {
            var response = new EventsDA().GetAllEventExpenseDetails(ExpenseDetailID);
            return PartialView("ExpenseDetails/_ViewEventExpenseDetails", response);
        }


        // GET: Expense Details By ID
        public PartialViewResult GetEventExpenseDetailByID(int ExpenseDetailID = 0, int EventID = 0)
        {
            if (ExpenseDetailID <= 0)
            {
                var expenseVo = new EventExpenseDetailsVO()
                {
                    CreatedBy = Session["username"].ToString(),
                    EventID = EventID,
                    EventNameList = EventsDA.GetAllEventNames()
                };
                return PartialView("ExpenseDetails/_AddEventExpenseDetails", expenseVo);
            }
            else
            {
                var response = new EventsDA().GetEventExpenseDetailByID(ExpenseDetailID);
                return PartialView("ExpenseDetails/_AddEventExpenseDetails", response);
            }
        }


        [HttpPost]  // POST: Event Expense Details
        public bool AddEventExpenseDetail(EventExpenseDetailsVO expenseVo)
        {
            expenseVo.CreatedBy = Session["username"].ToString();

            var result = new EventsDA().AddUpdateEventExpenseDetail(expenseVo);

            if (result >= 1)
                return true;
            else
                return false;
        }

        [HttpPost] // DELETE: Expense Details
        public bool DeleteEventExpenseDetail(int ExpenseDetailID)
        {
            try
            {
                var result = new EventsDA().DeleteEventExpenseDetail(ExpenseDetailID);

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


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT GALLERY %%%%%%%%%%%%%%%%%%%//

        // GET: View All Events
        public PartialViewResult GetEventGalleryPhotosByEventID(string EventName)
        {
            var galleryVo = new List<EventGalleryVO>();
            var EventID = EventsDA.GetEventIDByEventName(EventName);

            if (EventID <= 0)
            {
                galleryVo.Add(new EventGalleryVO()
                {
                    EventID = 0,
                    EventNameList = EventsDA.GetAllEventNames()
                });
                return PartialView("Gallery/_ViewEventGallery", galleryVo);
            }
            else
            {
                var response = new EventsDA().GetEventGalleryPhotosByEventID(EventID);

                if (response.Count <= 0)
                {
                    galleryVo.Add(new EventGalleryVO()
                    {
                        EventID = 0,
                        EventNameList = EventsDA.GetAllEventNames(),
                        EventName = EventName
                    });
                    return PartialView("Gallery/_ViewEventGallery", galleryVo);
                }

                return PartialView("Gallery/_ViewEventGallery", response);
            }
        }


        // GET: Events
        public PartialViewResult GetAddEventGalleryView()
        {
            var paymentsVo = new EventGalleryVO()
            {
                CreatedBy = Session["username"].ToString(),
                ImageID = 0,
                EventID = 0,
                EventNameList = EventsDA.GetAllEventNames()
            };
            return PartialView("Gallery/_AddEventGallery", paymentsVo);
        }


        [HttpPost]  // POST: Event Expense Details
        public bool AddEventGallery(EventGalleryVO galleryVo)
        {
            try
            {
                int rowsEffected = 0;

                galleryVo.CreatedBy = Session["username"].ToString();

                if (!string.IsNullOrEmpty(galleryVo.Image1))
                    rowsEffected = rowsEffected + new EventsDA().AddEventPhotos(galleryVo, galleryVo.Image1);

                if (!string.IsNullOrEmpty(galleryVo.Image2))
                    rowsEffected = rowsEffected + new EventsDA().AddEventPhotos(galleryVo, galleryVo.Image2);

                if (!string.IsNullOrEmpty(galleryVo.Image3))
                    rowsEffected = rowsEffected + new EventsDA().AddEventPhotos(galleryVo, galleryVo.Image3);

                if (rowsEffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public bool DeleteEventPhoto(int ImageID)
        {
            try
            {
                var result = new EventsDA().DeleteEventPhotos(ImageID);

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
    }
}