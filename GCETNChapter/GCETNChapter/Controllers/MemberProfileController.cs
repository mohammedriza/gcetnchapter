using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class MemberProfileController : Controller
    {
        private void GetDropdownListDataForRegistrationPage()
        {            
            ViewBag.GenderList = MemberDA.GetGenderList();
            ViewBag.CountryList = MemberDA.GetCountryList();
            ViewBag.BranchList = MemberDA.GetBranchList();
            ViewBag.BatchList = MemberDA.GetBatchList();
        }

        // GET: MemberProfile
        public ActionResult MyProfile(string RequestUser)
        {
            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            if (!string.IsNullOrEmpty(RequestUser))
                ViewBag.RequestUser = RequestUser;
            
            GetDropdownListDataForRegistrationPage();

            return View();
        }


        public PartialViewResult GetProfileLoginAndPersonalInfo(string RequestUser)
        {
            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            ViewBag.GenderList = MemberDA.GetGenderList();
            var response = new MemberProfileDA().GetProfileLoginAndPersonalInfo(username);

            return PartialView("MemberProfile/_LoginAndPersonalInfo", response);
        }

        public PartialViewResult GetProfileContactInformation(string RequestUser)
        {
            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            var response = new MemberProfileDA().GetProfileContactInformation(username);

            return PartialView("MemberProfile/_ContactInformation", response);
        }

        public PartialViewResult GetProfileAddressInformation(string RequestUser)
        {
            ViewBag.CountryList = MemberDA.GetCountryList();

            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            var response = new MemberProfileDA().GetProfileAddressInformation(username);

            return PartialView("MemberProfile/_AddressInformation", response);
        }

        public PartialViewResult GetProfileCollegeInformation(string RequestUser)
        {
            ViewBag.BranchList = MemberDA.GetBranchList();
            ViewBag.BatchList = MemberDA.GetBatchList();

            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            var response = new MemberProfileDA().GetProfileCollegeInformation(username);

            return PartialView("MemberProfile/_CollegeInformation", response);
        }

        public PartialViewResult GetProfileWorkplaceAndExpertiseInfo(string RequestUser)
        {
            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            var response = new MemberProfileDA().GetProfileWorkplaceAndExpertiseInfo(username);

            return PartialView("MemberProfile/_WorkplaceAndExpertiseInformation", response);
        }


        [HttpPost]
        public bool UpdatePersonalAndLoginInfo(MemberProfileVO profileVo)
        {
            //-- Username is always picked from the Username Tetxbox for login and personal info updates as the username field is already pulled from database --//
            profileVo.ActionUser = Session["username"].ToString();
            var response = new MemberProfileDA().UpdatePersonalAndLoginInfo(profileVo);

            if (response >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool UpdateProfileAddressInformation(MemberProfileVO profileVo)
        {
            //-- If Admin has not selected a user id (not returned in profileVo.Username), then use loggedIn user's username --//
            if (string.IsNullOrEmpty(profileVo.Username))
                profileVo.Username = Session["username"].ToString();

            profileVo.ActionUser = Session["username"].ToString();
            var response = new MemberProfileDA().UpdateProfileAddressInformation(profileVo);

            if (response >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool UpdateProfileCollegeInformation(MemberProfileVO profileVo)
        {
            //-- If Admin has not selected a user id (not returned in profileVo.Username), then use loggedIn user's username --//
            if (string.IsNullOrEmpty(profileVo.Username))
                profileVo.Username = Session["username"].ToString();

            profileVo.ActionUser = Session["username"].ToString();
            var response = new MemberProfileDA().UpdateProfileCollegeInformation(profileVo);

            if (response >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool UpdateProfileContactInformation(MemberProfileVO profileVo)
        {
            //-- If Admin has not selected a user id (not returned in profileVo.Username), then use loggedIn user's username --//
            if (string.IsNullOrEmpty(profileVo.Username))
                profileVo.Username = Session["username"].ToString();

            profileVo.ActionUser = Session["username"].ToString();
            var response = new MemberProfileDA().UpdateProfileContactInformation(profileVo);

            if (response >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool UpdateProfileWorkplaceAndExpertiseInfo(MemberProfileVO profileVo)
        {
            //-- If Admin has not selected a user id (not returned in profileVo.Username), then use loggedIn user's username --//
            if (string.IsNullOrEmpty(profileVo.Username))
                profileVo.Username = Session["username"].ToString();

            profileVo.ActionUser = Session["username"].ToString();
            var response = new MemberProfileDA().UpdateProfileWorkplaceAndExpertiseInfo(profileVo);

            if (response >= 1)
                return true;
            else
                return false;
        }


        public ActionResult Logout()
        {
            Session.Remove("username");
            Session.Remove("fullname");
            Session.Remove("logininfo");

            return View();
        }

    }
}