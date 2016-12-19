using GCETNChapter.Models.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class EventsDA
    {
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
                        EventID = response.ElementAt(x).EventID,
                        CollegeRegistrationNo = response.ElementAt(x).CollegeRegistrationNo,
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


    }
}