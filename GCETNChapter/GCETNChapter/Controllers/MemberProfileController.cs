using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class MemberProfileController : Controller
    {
        //--- CHECK IF USER'S SESSION EXIST. ELSE REDIRECT TO HOME PAGE ---//
        private void CheckSessionStatus()
        {
            if (Session["username"] == null)
                Response.Redirect("~/Home/Index/");
        }

        //--- Check if User is authorized to VIEW other user's profiles ---//
        private bool IsAuthorizedToVIEWProfile(string ProfileOwner)
        {
            if ((Session["username"].ToString() != ProfileOwner) && (!string.IsNullOrEmpty(ProfileOwner)))
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(127);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
                return authorize;
            }
            else
                return true;
        }

        //--- Check if User is authorized to UPDATE other user's profiles ---//
        private bool IsAuthorizedToUPDATEProfile(string ProfileOwner)
        {
            if ((Session["username"].ToString() != ProfileOwner) && (!string.IsNullOrEmpty(ProfileOwner)))
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(121);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
                return authorize;
            }
            else
                return true;
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

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToVIEWProfile(RequestUser);
            if (authorize == false)
            {
                return PartialView("_UnauthorizedAccess");
            }
            else
            {
                //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
                var username = Session["username"].ToString();
                if (!string.IsNullOrEmpty(RequestUser))
                    username = RequestUser;

                ViewBag.GenderList = MemberDA.GetGenderList();
                var response = new MemberProfileDA().GetProfileLoginAndPersonalInfo(username);

                return PartialView("Profile/_LoginAndPersonalInfo", response);
            }
        }

        public PartialViewResult GetProfileContactInformation(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToVIEWProfile(RequestUser);
            if (authorize == false)
            {
                return PartialView("_UnauthorizedAccess");
            }
            else
            {
                //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
                var username = Session["username"].ToString();
                if (!string.IsNullOrEmpty(RequestUser))
                    username = RequestUser;

                var response = new MemberProfileDA().GetProfileContactInformation(username);

                return PartialView("Profile/_ContactInformation", response);
            }
        }

        public PartialViewResult GetProfileAddressInformation(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToVIEWProfile(RequestUser);
            if (authorize == false)
            {
                return PartialView("_UnauthorizedAccess");
            }
            else
            {
                ViewBag.CountryList = MemberDA.GetCountryList();

                //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
                var username = Session["username"].ToString();
                if (!string.IsNullOrEmpty(RequestUser))
                    username = RequestUser;

                var response = new MemberProfileDA().GetProfileAddressInformation(username);

                return PartialView("Profile/_AddressInformation", response);
            }
        }

        public PartialViewResult GetProfileCollegeInformation(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToVIEWProfile(RequestUser);
            if (authorize == false)
            {
                return PartialView("_UnauthorizedAccess");
            }
            else
            {
                ViewBag.BranchList = MemberDA.GetBranchList();
                ViewBag.BatchList = MemberDA.GetBatchList();

                //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
                var username = Session["username"].ToString();
                if (!string.IsNullOrEmpty(RequestUser))
                    username = RequestUser;

                var response = new MemberProfileDA().GetProfileCollegeInformation(username);

                return PartialView("Profile/_CollegeInformation", response);
            }
        }

        public PartialViewResult GetProfileWorkplaceAndExpertiseInfo(string RequestUser)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToVIEWProfile(RequestUser);
            if (authorize == false)
            {
                return PartialView("_UnauthorizedAccess");
            }
            else
            {
                //-- 'RequestUser' parameter is parsed by admin when modifying another user's profile, else use loggedIn user's username --//
                var username = Session["username"].ToString();
                if (!string.IsNullOrEmpty(RequestUser))
                    username = RequestUser;

                var response = new MemberProfileDA().GetProfileWorkplaceAndExpertiseInfo(username);

                return PartialView("Profile/_WorkplaceAndExpertiseInformation", response);
            }
        }


        [HttpPost]
        public string UpdatePersonalAndLoginInfo(MemberProfileVO profileVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToUPDATEProfile(profileVo.Username);
            if (authorize == false)
            {
                return "401";
            }
            else
            {
                if (Request.Files.Count > 0)
                {
                    for (int x = 0; x < Request.Files.Count; x++)
                    {
                        var file = Request.Files[x];

                        if (file != null && file.ContentLength > 0)
                        {
                            //--- Upload File to Folder Location ---//
                            profileVo.ProfileImage = string.Format("{0}_{1}", profileVo.Username, Path.GetFileName(file.FileName));

                            var path = Path.Combine(Server.MapPath("~/_ImageUploads/MemberProfile/"), profileVo.ProfileImage);
                            file.SaveAs(path);
                        }
                    }
                }

                //--- Add Record to Database ---//
                //-- Username is always picked from the Username Tetxbox for login and personal info updates as the username field is already pulled from database --//
                profileVo.ActionUser = Session["username"].ToString();
                var response = new MemberProfileDA().UpdatePersonalAndLoginInfo(profileVo);

                if (response >= 1)
                    return "Success";
                else
                    return "Error";
            }
        }


        [HttpPost]
        public string UpdateProfileAddressInformation(MemberProfileVO profileVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToUPDATEProfile(profileVo.Username);
            if (authorize == false)
            {
                return "401";
            }
            else
            {
                //-- If Admin has not selected a user id (not returned in profileVo.Username), then use loggedIn user's username --//
                if (string.IsNullOrEmpty(profileVo.Username))
                    profileVo.Username = Session["username"].ToString();

                profileVo.ActionUser = Session["username"].ToString();
                var response = new MemberProfileDA().UpdateProfileAddressInformation(profileVo);

                if (response >= 1)
                    return "Success";
                else
                    return "Error";
            }
        }

        [HttpPost]
        public string UpdateProfileCollegeInformation(MemberProfileVO profileVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToUPDATEProfile(profileVo.Username);
            if (authorize == false)
            {
                return "401";
            }
            else
            {
                //-- If Admin has not selected a user id (not returned in profileVo.Username), then use loggedIn user's username --//
                if (string.IsNullOrEmpty(profileVo.Username))
                    profileVo.Username = Session["username"].ToString();

                profileVo.ActionUser = Session["username"].ToString();
                var response = new MemberProfileDA().UpdateProfileCollegeInformation(profileVo);

                if (response >= 1)
                    return "Success";
                else
                    return "Error";
            }
        }

        [HttpPost]
        public string UpdateProfileContactInformation(MemberProfileVO profileVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToUPDATEProfile(profileVo.Username);
            if (authorize == false)
            {
                return "401";
            }
            else
            {
                //-- If Admin has not selected a user id (not returned in profileVo.Username), then use loggedIn user's username --//
                if (string.IsNullOrEmpty(profileVo.Username))
                    profileVo.Username = Session["username"].ToString();

                profileVo.ActionUser = Session["username"].ToString();
                var response = new MemberProfileDA().UpdateProfileContactInformation(profileVo);

                if (response >= 1)
                    return "Success";
                else
                    return "Error";
            }
        }

        [HttpPost]
        public string UpdateProfileWorkplaceAndExpertiseInfo(MemberProfileVO profileVo)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            var authorize = IsAuthorizedToUPDATEProfile(profileVo.Username);
            if (authorize == false)
            {
                return "401";
            }
            else
            {
                //-- If Admin has not selected a user id (not returned in profileVo.Username), then use loggedIn user's username --//
                if (string.IsNullOrEmpty(profileVo.Username))
                    profileVo.Username = Session["username"].ToString();

                profileVo.ActionUser = Session["username"].ToString();
                var response = new MemberProfileDA().UpdateProfileWorkplaceAndExpertiseInfo(profileVo);

                if (response >= 1)
                    return "Success";
                else
                    return "Error";
            }
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

            var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(123);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

            if (authorize == false)
                return PartialView("_UnauthorizedAccess");
            else
            {
                var response = new MemberProfileDA().GetUsersDetails(null);
                return PartialView("User/_ViewUserList", response);
            }
        }


        // GET: Return User Details By Username
        public PartialViewResult GetUserAccountDetailsByUsername(string Username)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(120);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

            if (authorize == false)
                return PartialView("_UnauthorizedAccess");
            else
            {
                ViewBag.AccessRoleList = new MemberProfileDA().GetUserAccessRoleList();
                ViewBag.AccountStatusList = new MemberProfileDA().GetUserAccountStatusList();

                var response = new MemberProfileDA().GetUsersDetailsByUserID(Username);
                return PartialView("User/_AddUpdateUser", response);
            }
        }


        // POST: Create New OR Update Existing User Account
        [HttpPost]
        public string CreateUpdateUserDetails(UserVO Users, string TransType)
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            //--- Check this only if its a ADD Transaction --//
            if (TransType == "ADD")
            {
                var authorize1 = new GeneralFunctionsDA().GetAccessLevelAuthorization(119);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize1 == false)
                    return "401";
                else
                {
                    var ExistUsername = MemberDA.CheckIfUsernameExist(Users.Username);
                    var ExistCollegeRegNo = MemberDA.CheckIfCollegeRegNoExist(Users.CollegeRegistrationNo);

                    if (!string.IsNullOrEmpty(ExistUsername))
                        return "User Exist";
                    else if (!string.IsNullOrEmpty(ExistCollegeRegNo))
                        return "CollegeRegNo Exist";
                }
            }

            //--- Check this only if its a UPDATE Transaction --//
            if (TransType == "UPDATE")
            {
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(120);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return "401";
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
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(122);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return "401";
                else
                {
                    var rowsEffected = new MemberProfileDA().DeleteUserAccount(Username);

                    if (rowsEffected >= 1)
                        return "Success";
                    else
                        return "Error";
                }
            }
            catch(Exception ex)
            {
                if (ex.GetType().ToString() == "System.Data.Entity.Core.EntityCommandExecutionException")
                    return "ChildRecordsFound";
            }
            return null;
        }


        //--- ALL MEMBERS RELATED METHODS ---//
        public PartialViewResult GetAllMembers()
        {
            try
            {
                var members = new MemberProfileDA().GetAllMembers();
                return PartialView("Members/_AllMembers", members);
            }
            catch(Exception ex)
            {
                return PartialView("Members/_AllMembers", ex.Message);
            }
        }
    }
}