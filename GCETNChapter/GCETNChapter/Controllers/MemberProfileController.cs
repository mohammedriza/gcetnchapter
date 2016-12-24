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
        //--- CHECK IF USER'S SESSION EXIST. ELSE REDIRECT TO HOME PAGE ---//
        public void CheckSessionStatus()
        {
            if (Session["username"] == null)
                Response.Redirect("~/Home/Index/");
        }

        private void GetDropdownListDataForRegistrationPage()
        {            
            ViewBag.GenderList = MemberDA.GetGenderList();
            ViewBag.CountryList = MemberDA.GetCountryList();
            ViewBag.BranchList = MemberDA.GetBranchList();
            ViewBag.BatchList = MemberDA.GetBatchList();
        }

        // GET: MemberProfile
        public ActionResult ManageProfile(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- Get Dropdown Values for AddUpdateUser View
            ViewBag.AccessRoleList = new MemberProfileDA().GetUserAccessRoleList();
            ViewBag.AccountStatusList = new MemberProfileDA().GetUserAccountStatusList();

            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            if (!string.IsNullOrEmpty(RequestUser))
                ViewBag.RequestUser = RequestUser;
            
            GetDropdownListDataForRegistrationPage();

            return View();
        }


        public PartialViewResult GetProfileLoginAndPersonalInfo(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            ViewBag.GenderList = MemberDA.GetGenderList();
            var response = new MemberProfileDA().GetProfileLoginAndPersonalInfo(username);

            return PartialView("Profile/_LoginAndPersonalInfo", response);
        }

        public PartialViewResult GetProfileContactInformation(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            var response = new MemberProfileDA().GetProfileContactInformation(username);

            return PartialView("Profile/_ContactInformation", response);
        }

        public PartialViewResult GetProfileAddressInformation(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            ViewBag.CountryList = MemberDA.GetCountryList();

            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            var response = new MemberProfileDA().GetProfileAddressInformation(username);

            return PartialView("Profile/_AddressInformation", response);
        }

        public PartialViewResult GetProfileCollegeInformation(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            ViewBag.BranchList = MemberDA.GetBranchList();
            ViewBag.BatchList = MemberDA.GetBatchList();

            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            var response = new MemberProfileDA().GetProfileCollegeInformation(username);

            return PartialView("Profile/_CollegeInformation", response);
        }

        public PartialViewResult GetProfileWorkplaceAndExpertiseInfo(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
            var username = Session["username"].ToString();
            if (!string.IsNullOrEmpty(RequestUser))
                username = RequestUser;

            var response = new MemberProfileDA().GetProfileWorkplaceAndExpertiseInfo(username);

            return PartialView("Profile/_WorkplaceAndExpertiseInformation", response);
        }


        [HttpPost]
        public bool UpdatePersonalAndLoginInfo(MemberProfileVO profileVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

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
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

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
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

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
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

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
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

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


        //************************************************--- MANAGE USER METHODS ---************************************************//
        // GET: Return All User Details
        public PartialViewResult GetAllUserAccountDetails()
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            var response = new MemberProfileDA().GetUsersDetails(null);
            return PartialView("User/_ViewUserList", response);
        }


        // GET: Return User Details By Username
        public PartialViewResult GetUserAccountDetailsByUsername(string Username)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            ViewBag.AccessRoleList = new MemberProfileDA().GetUserAccessRoleList();
            ViewBag.AccountStatusList = new MemberProfileDA().GetUserAccountStatusList();

            var response = new MemberProfileDA().GetUsersDetailsByUserID(Username);
            return PartialView("User/_AddUpdateUser", response);
        }


        // POST: Create New OR Update Existing User Account
        [HttpPost]
        public string CreateUpdateUserDetails(UserVO Users, string TransType)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            if (TransType == "ADD")
            {
                var ExistUsername = MemberDA.CheckIfUsernameExist(Users.Username);
                var ExistCollegeRegNo = MemberDA.CheckIfCollegeRegNoExist(Users.CollegeRegistrationNo);

                if (!string.IsNullOrEmpty(ExistUsername))
                    return "User Exist";
                else if (!string.IsNullOrEmpty(ExistCollegeRegNo))
                    return "CollegeRegNo Exist";
            }

            Users.CreatedBy = Session["username"].ToString();
            var rowsEffected = new MemberProfileDA().CreateUpdateUserDetails(Users);

            if (rowsEffected >= 1)
                return "Success";
            else
                return "Error";
        }


        // POST: Delete Existing User Account
        [HttpPost]
        public string DeleteUserAccount(string Username)
        {
            try
            {
                var rowsEffected = new MemberProfileDA().DeleteUserAccount(Username);

                if (rowsEffected >= 1)
                    return "Success";
                else
                    return "Error";
            }
            catch(Exception ex)
            {
                if (ex.GetType().ToString() == "System.Data.Entity.Core.EntityCommandExecutionException")
                    return "ChildRecordsFound";
            }
            return null;
        }
    }
}