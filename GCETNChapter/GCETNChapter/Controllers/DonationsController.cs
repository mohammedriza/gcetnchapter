﻿using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class DonationsController : Controller
    {
        // GET: Donations
        public ActionResult Donations()
        {
            return View();
        }


        public PartialViewResult GetAllDonatoinDetails()
        {
            var response = new DonationDetailsDA().GetAllDonationDetails();

            return PartialView("_ViewDonations", response);
        }

        public PartialViewResult GetDonatoinDetailsByDonationID(int DonationID)
        {
            var response = new DonationDetailsVO();
            response = new DonationDetailsDA().GetDonationDetailsByDonationID(DonationID);

            return PartialView("_AddDonations", response);
        }

        [HttpPost]
        public ActionResult AddDonations(DonationDetailsVO donationsVo)
        {
            try
            {
                var CollegeRegNoExist = MemberDA.CheckIfCollegeRegNoExist(donationsVo.CollegeRegistrationNo);

                if (string.IsNullOrEmpty(CollegeRegNoExist))
                {
                    ViewBag.Failure = "The College Registratoin No you entered does not exist. Please enter a valid College Registratoin No. \n\n NOTE: Please make sure the user is already registered as a member.";
                }
                else if (donationsVo.PaymentStartDate > donationsVo.PaymentEndDate)
                {
                    ViewBag.Failure = "Payment Start Date should be On or before Payment End Date. Please correct the informatoin and resubmit.";
                }
                else if (donationsVo.PaymentDate > DateTime.Now)
                {
                    ViewBag.Failure = string.Format("Payment Date should be On or before {0}. Please enter a valid Payment Date.", DateTime.Now.ToShortDateString());
                }
                else if (donationsVo.Amount.ToString().Length > 11)
                {
                    ViewBag.Failure = string.Format("Amount Paid should not exceed 8 digits and 2 decimals. E.g: 99999999.99 is the max value for this field.");
                }
                else
                {
                    donationsVo.CreatedBy = Session["username"].ToString();
                    var result = new DonationDetailsDA().AddUpdateDonationDetails(donationsVo);

                    if (result >= 1)
                        ViewBag.Success = "Donation details saved successfully.";
                    else
                        ViewBag.Failure = "Failed to save Donation details. Please try again later or contact your systems administrator for assistance.";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Failure = "Unexpected error had occured." + Environment.NewLine + " Error Description: " + ex.Message;
            }

            return View("Donations");
        }


        [HttpPost]
        public bool DeleteDonations(int DonationID)
        {
            try
            {
                var result = new DonationDetailsDA().DeleteDonations(DonationID);

                if (result >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}