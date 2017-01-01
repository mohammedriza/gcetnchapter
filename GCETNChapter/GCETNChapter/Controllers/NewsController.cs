using GCETNChapter.Models.DataAccess;
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
            var NewsFeed = new NewsDA().GetAllNewsFeed(0);
            return View(NewsFeed);
        }
    }
}