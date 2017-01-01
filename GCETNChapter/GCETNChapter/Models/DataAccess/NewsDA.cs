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
                        HeadLine = response.ElementAt(x).Headline,
                        NewsDetail = response.ElementAt(x).NewsDetail,
                        ImageFile = response.ElementAt(x).ImageFile,
                        CreatedDate = response.ElementAt(x).CreatedDate
                    });
                }

                return News;
            }
        }
    }
}