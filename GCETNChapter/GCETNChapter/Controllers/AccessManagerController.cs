using GCETNChapter.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class AccessManagerController : Controller
    {
        // GET: AccessManager
        public ActionResult ManageAccess()
        {
            ViewBag.AccessRoles = new MemberProfileDA().GetUserAccessRoleList();
            var accessLevels = new AccessManagerDA().GetUserAccessLevels("");

            return View(accessLevels);
        }


        public PartialViewResult GetAccessLevelsByUserRole(string AccessRole)
        {
            ViewBag.Role = AccessRole;
            ViewBag.AccessRoles = new MemberProfileDA().GetUserAccessRoleList();
            var accessLevels = new AccessManagerDA().GetUserAccessLevels(AccessRole);

            return PartialView("AccessLevel/_ManageAccessLevel", accessLevels);
        }
    }
}