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
            try
            {
                if ((Session["username"].ToString() != ProfileOwner) && (!string.IsNullOrEmpty(ProfileOwner)))
                {
                    var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(127);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
                    return authorize;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return false;
            }
        }

        //--- Check if User is authorized to UPDATE other user's profiles ---//
        private bool IsAuthorizedToUPDATEProfile(string ProfileOwner)
        {
            try
            {
                if ((Session["username"].ToString() != ProfileOwner) && (!string.IsNullOrEmpty(ProfileOwner)))
                {
                    var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(121);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
                    return authorize;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return false;
            }
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
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return View();
            }
        }


        public PartialViewResult GetProfileLoginAndPersonalInfo(string RequestUser)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("Profile/_LoginAndPersonalInfo");
            }
        }

        public PartialViewResult GetProfileContactInformation(string RequestUser)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("Profile/_ContactInformation");
            }
        }

        public PartialViewResult GetProfileAddressInformation(string RequestUser)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("Profile/_AddressInformation");
            }
        }

        public PartialViewResult GetProfileCollegeInformation(string RequestUser)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("Profile/_CollegeInformation");
            }
        }

        public PartialViewResult GetProfileWorkplaceAndExpertiseInfo(string RequestUser)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("Profile/_WorkplaceAndExpertiseInformation");
            }
        }


        [HttpPost]
        public string UpdatePersonalAndLoginInfo(MemberProfileVO profileVo)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

                //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
                var authorize = IsAuthorizedToUPDATEProfile(profileVo.Username);
                if (authorize == false)
                {
                    return "401";
                }
                else if (profileVo.Password.Length < 6 || profileVo.Password.Length > 25)
                {
                    return "PasswordLengthFailed";
                }
                else if (profileVo.Username.Length < 6 || profileVo.Username.Length > 25)
                {
                    return "UsernameLengthFailed";
                }
                else if ((!profileVo.Password.Any(char.IsUpper)) || (!profileVo.Password.Any(char.IsLower) || (!profileVo.Password.Any(char.IsNumber))))
                {
                    return "PasswordRuleFailed";
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
                                profileVo.ProfileImage = profileVo.ProfileImage.Replace(" ", "");

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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Error";
            }
        }


        [HttpPost]
        public string UpdateProfileAddressInformation(MemberProfileVO profileVo)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Error";
            }
        }

        [HttpPost]
        public string UpdateProfileCollegeInformation(MemberProfileVO profileVo)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Error";
            }
        }

        [HttpPost]
        public string UpdateProfileContactInformation(MemberProfileVO profileVo)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Error";
            }
        }

        [HttpPost]
        public string UpdateProfileWorkplaceAndExpertiseInfo(MemberProfileVO profileVo)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
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
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("User/_ViewUserList");
            }
        }


        // GET: Return User Details By Username
        public PartialViewResult GetUserAccountDetailsByUsername(string Username)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("User/_AddUpdateUser");
            }
        }


        // POST: Create New OR Update Existing User Account
        [HttpPost]
        public string CreateUpdateUserDetails(UserVO Users, string TransType)
        {
            try
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
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Error";
            }
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
                else
                {
                    new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                    return "Error";
                }
            }
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
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("Members/_AllMembers", ex.Message);
            }
        }


        //--- RESET PASSWORD ---//
        public string ResetPassword(string Username)
        {
            try
            {
                using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
                {
                    if (string.IsNullOrEmpty(Username))
                    {
                        return "NoUsername";
                    }
                    else
                    {
                        var response = db.prcResetPassword(Username, "password123");

                        if (response >= 1)
                        {
                            return "Success";
                        }
                        else
                        {
                            return "Error";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Error";
            }
        }

    }
}