using GCETNChapter.Models.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class NewsDA
    {

        public List<NewsVO> GetAllNewsFeed(int NewsID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var News = new List<NewsVO>();
                var response = db.prcGetNewsFeed(0).ToList();

                for (int x = 0; x < response.Count; x++)
                {
                    News.Add(new NewsVO()
                    {
                        NewsID = response.ElementAt(x).NewsID,
                        HeadLine = response.ElementAt(x).Headline,
                        NewsDetail = response.ElementAt(x).NewsDetail,
                        ImageFile = response.ElementAt(x).ImageFile,
                        CreatedDate = response.ElementAt(x).CreatedDate
                    });
                }

                return News;
            }
        }


        public List<NewsVO> GetNewsFeedByNewsID(int NewsID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var SQL = string.Format("SELECT NewsID, Headline ,NewsDetail ,ImageFile, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate FROM GCE_NewsFeed WHERE NewsID = {0}", NewsID);

                var NewsFeed = db.Database.SqlQuery<NewsVO>(SQL).ToList();
                return NewsFeed;
            }
        }



        public int AddUpdateNewsFeed(NewsVO news)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcAddUpdateNewsFeed(news.NewsID, news.HeadLine, news.NewsDetail, news.ImageFile, news.CreatedBy);
                return response;
            }
        }


        public int DeleteNewsFeed(int NewsID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcDeleteNewsFeed(NewsID);
                return response;
            }
        }


    }
}