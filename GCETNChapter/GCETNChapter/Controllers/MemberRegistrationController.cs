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
        // GET: MemberRegistration
        public ActionResult Registration()
        {
            ViewBag.GenderList = MemberDA.GetGenderList();
            ViewBag.CountryList = MemberDA.GetCountryList();
            ViewBag.BranchList = MemberDA.GetBranchList();

            return View();
        }


        [HttpPost]
        public ActionResult Registration(MemberRegistrationVO MemberVO)
        {

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