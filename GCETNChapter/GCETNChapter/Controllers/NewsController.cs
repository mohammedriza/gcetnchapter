using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels;
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
    }
}