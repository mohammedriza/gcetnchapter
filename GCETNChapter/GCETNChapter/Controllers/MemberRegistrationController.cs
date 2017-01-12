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
            try
            {
                GetDropdownListDataForRegistrationPage();

                return View();
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return View();
            }
        }


        [HttpPost]
        public ActionResult Registration(MemberRegistrationVO MemberVO)
        {
            try
            {
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
                    else if(MemberVO.CollegeRegistrationNo.Length > 9)
                    {
                        this.ModelState.AddModelError("CollegeRegistrationNo", "College Registration No should contain 9 or less characters.");
                    }
                    else if (MemberVO.Password.Length < 6 || MemberVO.Password.Length > 25)
                    {
                        this.ModelState.AddModelError("Password", "Password should contain atleast 1 Uppercase, 1 Lowercase and 1 Number. Password should be between 6 and 25 characters.");
                    }
                    else if (MemberVO.Username.Length < 6 || MemberVO.Username.Length > 25)
                    {
                        this.ModelState.AddModelError("Username", "Username should be between 6 and 25 characters.");
                    }
                    else if ((!MemberVO.Password.Any(char.IsUpper)) || (!MemberVO.Password.Any(char.IsLower) || (!MemberVO.Password.Any(char.IsNumber))))
                    {
                        this.ModelState.AddModelError("Password", "Password should contain atleast 1 Uppercase, 1 Lowercase and 1 Number. Password should be between 6 and 25 characters.");
                    }
                    else
                    {
                        var CollegeRegNoExist = MemberDA.CheckIfCollegeRegNoExist(MemberVO.CollegeRegistrationNo);
                        var usernameExist = MemberDA.CheckIfUsernameExist(MemberVO.Username);

                        //--- Check if the user's College Registration Number already exist in the MemberInfo table. If so show the below message, else continue registration.
                        if (!string.IsNullOrEmpty(CollegeRegNoExist))
                        {
                            ViewBag.Failure = string.Format("It seems like you have already registered using this College Registration No '{0}'. " +
                                "If it wasn't you, please contact the administrator for assistance.", MemberVO.CollegeRegistrationNo);
                        }
                        else if (!string.IsNullOrEmpty(usernameExist))
                        {
                            ViewBag.Failure = string.Format("The username ({0}) you entered already exist. Please choose different Username to complete registration.", MemberVO.Username);
                        }
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
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                ViewBag.Failure = ex.Message + " | " + ex.InnerException;
            }

            GetDropdownListDataForRegistrationPage();
            return View(MemberVO);
        }


        public ActionResult Login()
        {
            try
            {
                if (Session["username"] != null)
                    Response.Redirect("~/MemberProfile/ManageProfile/");

                return View();
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return View();
            }
        }


        [HttpPost]
        public string Login(string Username, string Password)
        {
            try
            {
                var result = new MemberDA().AuthenticateMember(Username, Password);

                if (result == null)
                {
                    return "Fail";
                }
                else
                {
                    if (result.AccountStatus == "PENDING")
                        return "Pending";
                    else if (result.AccountStatus == "INACTIVE")
                        return "Inactive";
                    else if (result.AccountStatus == "ACTIVE")
                    {
                        Session.Add("logininfo", result);
                        Session.Add("username", Username);
                        Session.Add("fullname", result.FullName);
                        return "Pass";
                    }
                }
            }
            catch(Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return null;
            }
            return null;
        }


    }
}