using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels;
using GCETNChapter.Models.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class EventsController : Controller
    {
        //--- CHECK IF USER'S SESSION EXIST. ELSE REDIRECT TO HOME PAGE ---//
        private void CheckSessionStatus()
        {
            if (Session["username"] == null)
                Response.Redirect("~/Home/Index/");
        }

        // GET: Events
        public ActionResult Events()
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

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
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
            var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(101);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

            if (authorize == false)
                return PartialView("_UnauthorizedAccess");
            else
            {
                var response = new EventsDA().GetAllEvents(0);
                return PartialView("ManageEvents/_ViewEvents", response);
            }
        }

        // GET: Events
        public PartialViewResult GetEventDetailsByEventID(int EventID = 0)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- ADD EVENT ---//
            if (EventID <= 0)
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(102);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return PartialView("_UnauthorizedAccess");
                else
                {
                    var eventsVo = new EventsVO()
                    {
                        CreatedBy = Session["username"].ToString()
                    };
                    return PartialView("ManageEvents/_AddEvents", eventsVo);
                }
            }
            //--- EDIT EVENT ---//
            else
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(103);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return PartialView("_UnauthorizedAccess");
                else
                {
                    var response = new EventsDA().GetEventByEventID(EventID);
                    return PartialView("ManageEvents/_AddEvents", response);
                }
            }
        }


        [HttpPost]  // POST: Add Events
        public bool AddNewEvent(EventsVO eventVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

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
        public string DeleteEvent(int EventID)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(104);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return "401";
                else
                {
                    var result = new EventsDA().DeleteEvent(EventID);

                    if (result >= 1)
                        return "Success";
                    else
                        return "Error";
                }
            }
            catch(Exception)
            {
                return "Error";
            }
        }


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT PAYMENT COLLECTIONS %%%%%%%%%%%%%%%%%%%//

        // GET: View All Events
        public PartialViewResult GetAllEventPaymentCollections(int PaymentCollectionID)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
            var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(105);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

            if (authorize == false)
                return PartialView("_UnauthorizedAccess");
            else
            {
                var response = new EventsDA().GetAllEventPaymentCollections(PaymentCollectionID);
                return PartialView("PaymentCollections/_ViewEventPaymentCollection", response);
            }
        }


        // GET: Events
        public PartialViewResult GetEventPaymentCollectionByID(int PaymentCollectionID = 0, int EventID = 0)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- ADD PAYMENT COLLECTION ---//
            if (PaymentCollectionID <= 0)
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(106);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return PartialView("_UnauthorizedAccess");
                else
                {
                    var paymentsVo = new EventPaymentCollectionVO()
                    {
                        CreatedBy = Session["username"].ToString(),
                        EventID = EventID,
                        EventNameList = EventsDA.GetAllEventNames()
                    };
                    return PartialView("PaymentCollections/_AddEventPaymentCollection", paymentsVo);
                }
            }
            //--- EDIT PAYMENT COLLECTION ---//
            else
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(107);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return PartialView("_UnauthorizedAccess");
                else
                {

                    var response = new EventsDA().GetEventPaymentCollectionByID(PaymentCollectionID);
                    return PartialView("PaymentCollections/_AddEventPaymentCollection", response);
                }
            }
        }


        [HttpPost]  // POST: Event Expense Details
        public bool AddEventPaymentCollection(EventPaymentCollectionVO eventPaymentVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

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
        public string DeleteEventPaymentCollection(int PaymentCollectionID)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(108);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return "401";
                else
                {
                    var result = new EventsDA().DeleteEventPaymentCollection(PaymentCollectionID);

                    if (result >= 1)
                        return "Success";
                    else
                        return "Error";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }



        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT EXPENSE DETAILS %%%%%%%%%%%%%%%%%%%//

        // GET: View All Event Expense Details
        public PartialViewResult GetAllEventExpenseDetails(int ExpenseDetailID)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
            var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(109);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

            if (authorize == false)
                return PartialView("_UnauthorizedAccess");
            else
            {
                var response = new EventsDA().GetAllEventExpenseDetails(ExpenseDetailID);
                return PartialView("ExpenseDetails/_ViewEventExpenseDetails", response);
            }
        }


        // GET: Expense Details By ID
        public PartialViewResult GetEventExpenseDetailByID(int ExpenseDetailID = 0, int EventID = 0)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- ADD EVENT EXPENSE DETAILS ---//
            if (ExpenseDetailID <= 0)
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(110);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return PartialView("_UnauthorizedAccess");
                else
                {
                    var expenseVo = new EventExpenseDetailsVO()
                    {
                        CreatedBy = Session["username"].ToString(),
                        EventID = EventID,
                        EventNameList = EventsDA.GetAllEventNames()
                    };
                    return PartialView("ExpenseDetails/_AddEventExpenseDetails", expenseVo);
                }
            }
            //--- VIEW EVENT EXPENSE DETAILS ---//
            else
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(111);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return PartialView("_UnauthorizedAccess");
                else
                {
                    var response = new EventsDA().GetEventExpenseDetailByID(ExpenseDetailID);
                    return PartialView("ExpenseDetails/_AddEventExpenseDetails", response);
                }
            }
        }


        [HttpPost]  // POST: Event Expense Details
        public bool AddEventExpenseDetail(EventExpenseDetailsVO expenseVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            expenseVo.CreatedBy = Session["username"].ToString();

            var result = new EventsDA().AddUpdateEventExpenseDetail(expenseVo);

            if (result >= 1)
                return true;
            else
                return false;
        }

        [HttpPost] // DELETE: Expense Details
        public string DeleteEventExpenseDetail(int ExpenseDetailID)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(112);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return "401";
                else
                {
                    var result = new EventsDA().DeleteEventExpenseDetail(ExpenseDetailID);

                    if (result >= 1)
                        return "Success";
                    else
                        return "Error";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT GALLERY %%%%%%%%%%%%%%%%%%%//

        // GET: View All Events
        public PartialViewResult GetEventGalleryPhotosByEventID(string EventName)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
            var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(113);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

            if (authorize == false)
                return PartialView("_UnauthorizedAccess");
            else
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
        }


        // GET: Events
        public PartialViewResult GetAddEventGalleryView()
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
            var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(114);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

            if (authorize == false)
                return PartialView("_UnauthorizedAccess");
            else
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
        }


        [HttpPost]  // POST: Event Expense Details
        public string AddEventGallery(EventGalleryVO galleryVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            try
            {
                int rowsEffected = 0;
                galleryVo.CreatedBy = Session["username"].ToString();

                if (Request.Files.Count > 0)
                {
                    for (int x = 0; x < Request.Files.Count; x++)
                    {
                        var file = Request.Files[x];

                        if (file != null && file.ContentLength > 0)
                        {
                            //--- Upload File to Folder Location ---//
                            string paramDatetime = (DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond).ToString();
                            galleryVo.ImageFileName = string.Format("{0}_{1}_{2}", galleryVo.EventID, paramDatetime, Path.GetFileName(file.FileName.Trim()));
                            galleryVo.ImageFileName = galleryVo.ImageFileName.Replace(" ", "");

                            var path = Path.Combine(Server.MapPath("~/_ImageUploads/EventPhotos/"), galleryVo.ImageFileName);
                            file.SaveAs(path);

                            //--- Add Record to Database ---//
                            rowsEffected = rowsEffected + new EventsDA().AddEventPhotos(galleryVo);
                        }
                    }
                }
                else
                {
                    return "NoFiles";
                }

                if (rowsEffected >= 1)
                    return "Success";
                else
                    return "Error";
            }
            catch (Exception)
            {
                return "Error";
            }
        }


        [HttpPost]
        public string DeleteEventPhoto(int ImageID)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(126);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return "401";
                else
                {
                    var result = new EventsDA().DeleteEventPhotos(ImageID);

                    if (result >= 1)
                        return "Success";
                    else
                        return "Error";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}