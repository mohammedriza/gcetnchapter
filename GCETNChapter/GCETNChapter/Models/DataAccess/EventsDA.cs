using GCETNChapter.Models.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class EventsDA
    {
        public static List<string> GetAllEventNames()
        {
            var EventNames = new List<string>();

            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var result = db.Database.SqlQuery<string>("SELECT EventName FROM GCE_Events").ToList();

                EventNames.Add("-- Select an Event --");
                for (int x = 0; x < result.Count; x++)
                {
                    EventNames.Add(result.ElementAt(x).ToString());
                }
            }
            return EventNames;
        }


        public static int GetEventIDByEventName(string EventName)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var result = db.prcGetEventIdByEventName(EventName).FirstOrDefault();
                return Convert.ToInt32(result);
            }
        }

        public static string CheckIfEventNameExist(string EventName)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var result = db.Database.SqlQuery<string>("SELECT EventName FROM GCE_Events WHERE EventName = '"+ EventName+"';").ToList();

                if (result.Count > 0)
                    return result[0].ToString();
                else
                    return null;
            }
        }


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENTS %%%%%%%%%%%%%%%%%%%//

        public int AddUpdateEventDetail(EventsVO eventVo)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcAddNewEvent(eventVo.EventID, eventVo.EventName, eventVo.StartDate, eventVo.EndDate, eventVo.TotalCollectedAmount, eventVo.TotalExpenseAmount, eventVo.CreatedBy);

                return response;
            }
        }


        public List<EventsVO> GetAllEvents(int EventID)
        {
            var Events = new List<EventsVO>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetEventDetails(EventID).ToList();

                if (EventID == 0)
                {
                    for (int x = 0; x < response.Count; x++)
                    {
                        Events.Add(new EventsVO
                        {
                            EventID = response.ElementAt(x).EventID,
                            EventName = response.ElementAt(x).EventName,
                            StartDate = response.ElementAt(x).StartDate,
                            EndDate = response.ElementAt(x).EndDate,
                            TotalCollectedAmount = Convert.ToDecimal(response.ElementAt(x).TotalCollectedAmount),
                            TotalExpenseAmount = Convert.ToDecimal(response.ElementAt(x).TotalExpenseAmount),
                            CreatedBy = response.ElementAt(x).CreatedBy,
                            CreatedDate = response.ElementAt(x).CreatedDate,
                            ModifiedBy = response.ElementAt(x).ModifiedBy,
                            ModifiedDate = response.ElementAt(x).ModifiedDate
                        });
                    }
                }
                return Events;
            }
        }


        public EventsVO GetEventByEventID(int EventID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetEventDetails(EventID).ToList();

                var Events = new EventsVO()
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
                return Events;
            }
        }


        public int DeleteEvent(int EventID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var rowsEffected = db.prcDeleteEvent(EventID);

                return rowsEffected;
            }
        }


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT PAYMENT COLLECTIONS %%%%%%%%%%%%%%%%%%%//

        public int AddUpdateEventPaymentCollection(EventPaymentCollectionVO paymentVo)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcAddUpdateEventPaymentCollection(paymentVo.PaymentCollectionID, paymentVo.EventID, paymentVo.CollegeRegistrationNo, paymentVo.PaymentDate, paymentVo.AmountReceived, paymentVo.CreatedBy);

                return response;
            }
        }

        public List<EventPaymentCollectionVO> GetAllEventPaymentCollections(int PaymentCollectionID)
        {
            var PaymentCollection = new List<EventPaymentCollectionVO>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetEventPaymentCollectionDetails(PaymentCollectionID).ToList();

                for (int x = 0; x < response.Count; x++)
                {
                    PaymentCollection.Add(new EventPaymentCollectionVO
                    {
                        PaymentCollectionID = response.ElementAt(x).PaymentCollectionID,
                        EventName = response.ElementAt(x).EventName,
                        EventID = response.ElementAt(x).EventID,
                        MemberName = response.ElementAt(x).FullName,
                        AmountReceived = response.ElementAt(x).AmountReceived,
                        PaymentDate = response.ElementAt(x).PaymentDate,
                        CreatedBy = response.ElementAt(x).CreatedBy,
                        CreatedDate = response.ElementAt(x).CreatedDate,
                        ModifiedBy = response.ElementAt(x).ModifiedBy,
                        ModifiedDate = response.ElementAt(x).ModifiedDate
                    });
                }
                return PaymentCollection;
            }
        }

        public EventPaymentCollectionVO GetEventPaymentCollectionByID(int PaymentCollectionID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetEventPaymentCollectionDetails(PaymentCollectionID).ToList();

                var PaymentCollection = new EventPaymentCollectionVO()
                {
                    PaymentCollectionID = response.ElementAt(0).PaymentCollectionID,
                    EventID = response.ElementAt(0).EventID,
                    EventName = response.ElementAt(0).EventName,
                    EventNameList = EventsDA.GetAllEventNames(),
                    MemberName = response.ElementAt(0).FullName,
                    CollegeRegistrationNo = response.ElementAt(0).CollegeRegistrationNo,
                    AmountReceived = response.ElementAt(0).AmountReceived,
                    PaymentDate = response.ElementAt(0).PaymentDate,
                    CreatedBy = response.ElementAt(0).CreatedBy,
                    CreatedDate = response.ElementAt(0).CreatedDate,
                    ModifiedBy = response.ElementAt(0).ModifiedBy,
                    ModifiedDate = response.ElementAt(0).ModifiedDate
                };
                return PaymentCollection;
            }
        }

        public int DeleteEventPaymentCollection(int PaymentCollectionID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var rowsEffected = db.prcDeleteEventPaymentCollection(PaymentCollectionID);

                return rowsEffected;
            }
        }



        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT EXPENSE DETAILS %%%%%%%%%%%%%%%%%%%//

        public int AddUpdateEventExpenseDetail(EventExpenseDetailsVO expenseVo)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcAddUpdateEventExpenseDetail(expenseVo.ExpenseDetailID, expenseVo.EventID, expenseVo.ExpenseDetail, expenseVo.ExpenseDate, expenseVo.Amount, expenseVo.CreatedBy);

                return response;
            }
        }

        public List<EventExpenseDetailsVO> GetAllEventExpenseDetails(int ExpenseDetailID)
        {
            var ExpenseDetail = new List<EventExpenseDetailsVO>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetEventExpenseDetails(ExpenseDetailID).ToList();

                for (int x = 0; x < response.Count; x++)
                {
                    ExpenseDetail.Add(new EventExpenseDetailsVO
                    {
                        ExpenseDetailID = response.ElementAt(x).ExpenseDetailID,
                        EventID = response.ElementAt(x).EventID,
                        EventName = response.ElementAt(x).EventName,
                        ExpenseDetail = response.ElementAt(x).ExpenseDetail,
                        Amount = response.ElementAt(x).Amount,
                        ExpenseDate = response.ElementAt(x).ExpenseDate,
                        CreatedBy = response.ElementAt(x).CreatedBy,
                        CreatedDate = response.ElementAt(x).CreatedDate,
                        ModifiedBy = response.ElementAt(x).ModifiedBy,
                        ModifiedDate = response.ElementAt(x).ModifiedDate
                    });
                }
                return ExpenseDetail;
            }
        }

        public EventExpenseDetailsVO GetEventExpenseDetailByID(int ExpenseDetailID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetEventExpenseDetails(ExpenseDetailID).ToList();

                var ExpenseDetail = new EventExpenseDetailsVO()
                {
                    ExpenseDetailID = response.ElementAt(0).ExpenseDetailID,
                    EventID = response.ElementAt(0).EventID,
                    EventName = response.ElementAt(0).EventName,
                    EventNameList = EventsDA.GetAllEventNames(),
                    ExpenseDetail = response.ElementAt(0).ExpenseDetail,
                    Amount = response.ElementAt(0).Amount,
                    ExpenseDate = response.ElementAt(0).ExpenseDate,
                    CreatedBy = response.ElementAt(0).CreatedBy,
                    CreatedDate = response.ElementAt(0).CreatedDate,
                    ModifiedBy = response.ElementAt(0).ModifiedBy,
                    ModifiedDate = response.ElementAt(0).ModifiedDate
                };
                return ExpenseDetail;
            }
        }

        public int DeleteEventExpenseDetail(int ExpenseDetailID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var rowsEffected = db.prcDeleteEventExpensedetail(ExpenseDetailID);

                return rowsEffected;
            }
        }


        //%%%%%%%%%%%%%%%%%%% MANAGE EVENT GALLERY %%%%%%%%%%%%%%%%%%%//

        public int AddEventPhotos(EventGalleryVO GalleryVo, string ImageName)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcAddEventPhotos(GalleryVo.EventID, ImageName, GalleryVo.CreatedBy);

                return response;
            }
        }


        public List<EventGalleryVO> GetEventGalleryPhotosByEventID(int EventID)
        {
            var ExpenseDetail = new List<EventGalleryVO>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetEventPhotosByEventID(EventID).ToList();

                for (int x = 0; x < response.Count; x++)
                {
                    ExpenseDetail.Add(new EventGalleryVO
                    {
                        ImageID = response.ElementAt(x).ImageID,
                        EventID = response.ElementAt(x).EventID,
                        EventNameList = EventsDA.GetAllEventNames(),
                        EventName = response.ElementAt(x).EventName,
                        Image1 = response.ElementAt(x).Image,
                        CreatedBy = response.ElementAt(x).CreatedBy,
                        CreatedDate = response.ElementAt(x).CreatedDate,
                        ModifiedBy = response.ElementAt(x).ModifiedBy,
                        ModifiedDate = response.ElementAt(x).ModifiedDate
                    });
                }
                return ExpenseDetail;
            }
        }


        public int DeleteEventPhotos(int ImageID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var rowsEffected = db.prcDeleteEventPhotos(ImageID);

                return rowsEffected;
            }
        }
    }
}