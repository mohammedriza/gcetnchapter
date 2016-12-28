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
            return View();
        }

        public ActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactForm(ContactUsVO contactUs)
        {
            var response = new HomeDA().InsertContactUsDetails(contactUs);

            if (response >= 1)
                return RedirectToAction("MessageSent");
            else
            {
                ViewBag.Failure = "Failed to send information to Trust group. Please try again later or contact them using the contact numbers provided in the site.";
                return View();
            }
        }

        //-- This view returns when the ContactForm method is completed successfully ---//
        public ActionResult MessageSent()
        {
            ViewBag.SuccessMessage = "Thank You for contacting us. Your message has been sent to the Trust group. We'll contact you shortly.";
            return View();
        }
    }
}