using GCETNChapter.Models.ViewModels;
using GCETNChapter.Models.ViewModels.Advertisement;
using GCETNChapter.Models.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class HomeDA
    {
        public int InsertContactUsDetails(ContactUsVO contactUs)
        {
            var rowsEffected = 0;

            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcInsertContactUsInfo(contactUs.Name, contactUs.Email, contactUs.Summary, contactUs.Messaage);
            }
            return rowsEffected;
        }


        public List<AdvertisementVO> GetActiveAdvertisements()
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var Ads = new List<AdvertisementVO>();
                var result = db.prcGetActiveAdvertisements().ToList();

                if (result.Count >= 1)
                {
                    for (int x = 0; x < result.Count; x++)
                    {
                        Ads.Add(new AdvertisementVO()
                        {
                            Title = result.ElementAt(x).Title,
                            Description = result.ElementAt(x).Description,
                            ImageFileName = result.ElementAt(x).ImageFileName,
                            Footer = result.ElementAt(x).Footer,
                            ExpiryDate = result.ElementAt(x).ExpiryDate
                        });
                    }
                }
                return Ads;
            }
        }


        public List<EventsVO> GetLatestEventsForPublicPage()
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var SQL = string.Format("SELECT TOP 2 E.EventID, E.EventName, E.StartDate, E.EndDate, G.Image "
                        + "FROM dbo.GCE_Events E, dbo.GCE_EventGallery G "
                        + "WHERE E.EventID = G.EventID "
                        + "AND G.Image = (SELECT TOP 1 EG.Image FROM dbo.GCE_EventGallery EG WHERE EG.EventID = G.EventID ORDER BY EG.CreatedDate DESC) "
                        + "ORDER BY E.CreatedDate DESC");

                var Events = db.Database.SqlQuery<EventsVO>(SQL).ToList();
                return Events;
            }
        }



    }
}