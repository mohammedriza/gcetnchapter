using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class MemberRegistrationController : Controller
    {
        private void GetDropdownListDataForRegistrationPage()
        {
            ViewBag.GenderList = MemberDA.GetGenderList();
            ViewBag.CountryList = MemberDA.GetCountryList();
            ViewBag.BranchList = MemberDA.GetBranchList();
            ViewBag.BatchList = MemberDA.GetBatchList();
        }

        // GET: MemberRegistration
        public ActionResult Registration()
        {
            GetDropdownListDataForRegistrationPage();

            return View();
        }


        [HttpPost]
        public ActionResult Registration(MemberRegistrationVO MemberVO)
        {
            //Session Created for testing purpose
            Session.Add("username", "SYSTEM");

            if (ModelState.IsValid)
            {
                if (MemberVO.Gender == "-- Select Gender --")
                {
                    this.ModelState.AddModelError("Gender", "Please select a Gender.");
                }
                else if (MemberVO.Batch.ToString() == "-- Select Batch --")
                {
                    this.ModelState.AddModelError("Batch", "Please select a Batch.");
                }
                else if (MemberVO.Branch == "-- Select Branch --")
                {
                    this.ModelState.AddModelError("Branch", "Please select a Branch.");
                }
                else if (MemberVO.CurrentCountry == "-- Select Country --")
                {
                    this.ModelState.AddModelError("CurrentCountry", "Please select a Country.");
                }
                else if (MemberVO.PermanentCountry == "-- Select Country --")
                {
                    this.ModelState.AddModelError("PermanentCountry", "Please select a Country.");
                }
                else
                {
                    var CollegeRegNoExist = MemberDA.CheckIfCollegeRegNoExist(MemberVO.CollegeRegistrationNo);
                    var usernameExist = MemberDA.CheckIfUsernameExist(MemberVO.Username);

                    //--- Check if the user's College Registration Number already exist in the MemberInfo table. If so show the below message, else continue registration.
                    if (!string.IsNullOrEmpty(CollegeRegNoExist))
                        ViewBag.Failure = string.Format("It seems like you have already registered using this College Registration No '{0}'. " +
                            "If it wasn't you, please contact the administrator for assistance.", MemberVO.CollegeRegistrationNo);
                    else if (!string.IsNullOrEmpty(usernameExist))
                        ViewBag.Failure = string.Format("The username ({0}) you used already exist. Please use a different Username to complete registration.", MemberVO.Username);
                    else
                    {
                        var result = new MemberDA().RegisterNewMemberInRegistrationPage(MemberVO);

                        if (result >= 1)
                            ViewBag.Success = "You have successfully registered as a member. " +
                                "Your account is assigned to a Batch, Trust or an Admin to approve. You will be able to access your account once your account is approved.";
                        else
                            ViewBag.Failure = "An unexpected error had occured while trying to register your account. Please try again later or contact your systems administrator.";
                    }
                }
            }

            GetDropdownListDataForRegistrationPage();

            return View(MemberVO);
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {

            return View();
        }


    }
}