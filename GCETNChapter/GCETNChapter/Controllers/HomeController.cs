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
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

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

        public ActionResult Gallery()
        {
            //var response = new HomeDA().GetLatestEventsForPublicPage();
            //return View(response);
            return View();
        }

        public ActionResult Events()
        {
            try
            {
                var response = new HomeDA().GetLatestEventsForPublicPage();
                return View(response);
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return View();
            }
        }

        [HttpPost]
        public ActionResult ContactForm(ContactUsVO contactUs)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return View();
            }
        }

        //-- This view returns when the ContactForm method is completed successfully ---//
        public ActionResult MessageSent()
        {
            ViewBag.SuccessMessage = "Thank You for contacting us. Your message has been sent to the Trust group. We'll contact you shortly.";
            return View();
        }


        //---- GET LIST OF ACTIVE ADVERTISEMENTS TO SCROLL IN MARQUEE ---//
        public PartialViewResult GetActiveAdvertisements()
        {
            try
            {
                var ActiveAds = new HomeDA().GetActiveAdvertisements();
                return PartialView("Index/_Advertisement", ActiveAds);
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("Index/_Advertisement");
            }
        }
    }
}