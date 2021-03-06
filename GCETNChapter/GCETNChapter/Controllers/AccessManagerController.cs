﻿using GCETNChapter.Models.DataAccess;
using GCETNChapter.Models.ViewModels.ManageAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class AccessManagerController : Controller
    {
        //--- CHECK IF USER'S SESSION EXIST. ELSE REDIRECT TO HOME PAGE ---//
        private void CheckSessionStatus()
        {
            if (Session["username"] == null)
                Response.Redirect("~/Home/Index/");
        }


        //--- CHECK FOR ACCESS AUTHORIZATION STATUS ---//
        public bool CheckForAccessAuthorization(string Value)
        {
            int AccessID = Convert.ToInt32(Value);
            var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(AccessID);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//
            return authorize;
        }


        // GET: AccessManager
        public ActionResult ManageAccess()
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

                ViewBag.AccessRoles = new MemberProfileDA().GetUserAccessRoleList();
                //var accessLevels = new AccessManagerDA().GetUserAccessLevels("");

                return View();
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return View();
            }
        }


        public PartialViewResult GetAccessLevelsByUserRole(string AccessRole)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(125);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return PartialView("_UnauthorizedAccess");
                else
                {
                    ViewBag.Role = AccessRole;
                    ViewBag.AccessRoles = new MemberProfileDA().GetUserAccessRoleList();
                    var accessLevels = new AccessManagerDA().GetUserAccessLevels(AccessRole);

                    return PartialView("AccessLevel/_ManageAccessLevel", accessLevels);
                }
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return PartialView("AccessLevel/_ManageAccessLevel");
            }
        }


        [HttpPost]
        public int AddNewAccessRole(string AccessRole)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(124);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return 401;
                else
                {
                    var CreatedBy = Session["username"].ToString();
                    var result = new AccessManagerDA().AddNewAccessRole(AccessRole, CreatedBy);

                    return result;
                }
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return 0;
            }
        }


        [HttpPost]
        public string AddUpdateAccessRights(AccessLevelsVO accessLevel)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//
                var authorize = new GeneralFunctionsDA().GetAccessLevelAuthorization(125);  //--- CHECK IF USER IS AUTHORIZED TO PERFORM THIS FUNCTION ---//

                if (authorize == false)
                    return "401";
                else
                {
                    accessLevel.CreatedBy = Session["username"].ToString();
                    var rowsEffected = new AccessManagerDA().prcAddUpdateAccessRights(accessLevel);

                    if (rowsEffected >= 1)
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
        public string DeleteAccessRole(string AccessRole)
        {
            try
            {
                var rowsEffected = new AccessManagerDA().DeleteAccessRole(AccessRole);

                if (rowsEffected >= 1)
                    return "Success";
                else
                    return "Error";
            }
            catch (Exception ex)
            {
                new ErrorDA().BuildErrorDetails(ex, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString());
                return "Exception: " + ex.InnerException;
            }
        }



    }
}