using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ContactForm()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ContactForm(ContactUsVO contactUs)
        {
            var response = new HomeDA().InsertContactUsDetails(contactUs);
            var emptyView = new ContactUsVO();

            if (response >= 1)
                ViewBag.Success = "Thank You for contacting us. Your message has been sent to the Trust group. We'll contact you shortly.";
            else
                ViewBag.Failure = "Failed to send information to Trust group. Please try again later or contact them using the contact numbers provided in the site.";

            return View(emptyView);
        }
    }
}