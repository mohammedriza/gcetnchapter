using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels;
using GCETNChapter.Models.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult ViewNews()
        {
            try
            {
                if (Session["logininfo"] == null)
                {
                    ViewBag.AccessRole = "Guest";
                }
                else
                {
                    var userInfo = (LoginDetailsVO)Session["logininfo"];
                    ViewBag.AccessRole = userInfo.AccessRole;
                }

                var NewsFeed = new NewsDA().GetAllNewsFeed(0);
                return View(NewsFeed);
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return View();
            }
        }


        public PartialViewResult GetNewsFeedByNewsID(int NewsID)
        {
            try
            {
                if (NewsID == 0)
                {
                    var news = new List<NewsVO>();
                    news.Add(new NewsVO()
                    {
                        NewsID = 0,
                        HeadLine = "",
                        NewsDetail = "",
                        ImageFile = ""
                    });
                    return PartialView("_AddUpdateNewsFeedModal", news);
                }
                else
                {
                    var result = new NewsDA().GetNewsFeedByNewsID(NewsID);
                    return PartialView("_AddUpdateNewsFeedModal", result);
                }
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("_AddUpdateNewsFeedModal");
            }
        }


        [HttpPost]
        public string AddUpdateNewsFeed(NewsVO news)
        {
            try
            {
                news.CreatedBy = Session["username"].ToString();
                var rowsEffected = new NewsDA().AddUpdateNewsFeed(news);

                if (rowsEffected >= 1)
                    return "Success";
                else
                    return "Error";
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Error";
            }
        }


        [HttpPost]
        public string DeleteNewsFeed(int NewsID)
        {
            try
            {
                var rowsEffected = new NewsDA().DeleteNewsFeed(NewsID);

                if (rowsEffected >= 1)
                    return "Success";
                else
                    return "Error";
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Exception: " + ex.InnerException;
            }
        }



    }
}