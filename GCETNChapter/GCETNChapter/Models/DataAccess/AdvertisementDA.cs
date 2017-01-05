using GCETNChapter.Models.ViewModels.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class AdvertisementDA
    {

        public int AddUpdateAdvertisements(AdvertisementVO AdsVo)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcAddUpdateAdvertisements(AdsVo.AdvertisementID, AdsVo.Title, AdsVo.Description, AdsVo.Footer, AdsVo.ImageFileName, AdsVo.StartDate, AdsVo.ExpiryDate, AdsVo.CreatedBy);
                return response;
            }
        }


        public List<AdvertisementVO> GetAllAdvertisements()
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var Ads = new List<AdvertisementVO>();

                var response = db.prcGetAdvertisementDetails(0).ToList();

                if (response.Count >= 1)
                {
                    for (int x = 0; x < response.Count; x++)
                    {
                        Ads.Add(new AdvertisementVO()
                        {
                            AdvertisementID = response.ElementAt(x).AdvertisementID,
                            Title = response.ElementAt(x).Title,
                            Description = response.ElementAt(x).Description,
                            Footer = response.ElementAt(x).Footer,
                            StartDate = response.ElementAt(x).StartDate,
                            ExpiryDate = response.ElementAt(x).ExpiryDate,
                            ImageFileName = response.ElementAt(x).ImageFileName,
                            Status = response.ElementAt(x).Status,
                            CreatedBy = response.ElementAt(x).CreatedBy,
                            CreatedDate = response.ElementAt(x).CreatedDate,
                            ModifiedBy = response.ElementAt(x).ModifiedBy,
                            ModifiedDate = response.ElementAt(x).ModifiedDate
                        });
                    }
                }
                return Ads;
            }
        }


        public AdvertisementVO GetAdvertisementsByID(int AdID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetAdvertisementDetails(AdID).ToList();

                if (response != null)
                {
                    var Ads = new AdvertisementVO()
                    {
                        AdvertisementID = response.ElementAt(0).AdvertisementID,
                        Title = response.ElementAt(0).Title,
                        Description = response.ElementAt(0).Description,
                        Footer = response.ElementAt(0).Footer,
                        StartDate = response.ElementAt(0).StartDate,
                        ExpiryDate = response.ElementAt(0).ExpiryDate,
                        ImageFileName = response.ElementAt(0).ImageFileName,
                        Status = response.ElementAt(0).Status,
                        CreatedBy = response.ElementAt(0).CreatedBy,
                        CreatedDate = response.ElementAt(0).CreatedDate,
                        ModifiedBy = response.ElementAt(0).ModifiedBy,
                        ModifiedDate = response.ElementAt(0).ModifiedDate
                    };
                    return Ads;
                }
                return null;
            }
        }


        public int DeleteAdvertisements(int AdID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcDeleteAdvertisement(AdID);
                return response;
            }
        }



    }
}