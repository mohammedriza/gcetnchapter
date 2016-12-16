using GCETNChapter.Models.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class EventsDA
    {
        public int AddNewEventDetail(EventsVO eventVo)
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
                return Events;
            }
        }
    }
}