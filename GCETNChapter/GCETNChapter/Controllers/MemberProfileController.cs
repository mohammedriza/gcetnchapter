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
        public ActionResult MyProfile()
        {
            Session.Add("username", "mohammedrizarazik");
            Session.Add("fullname", "Mohamed Riza");
            GetDropdownListDataForRegistrationPage();

            var profile = new MemberProfileVO()
            {
                Username = Session["username"].ToString()
            };                
            return View(profile);
        }


        public PartialViewResult GetProfileLoginAndPersonalInfo()
        {
            GetDropdownListDataForRegistrationPage();

            var username = Session["username"].ToString();
            var response = new MemberProfileDA().GetProfileLoginAndPersonalInfo(username);

            return PartialView("MemberProfile/_LoginAndPersonalInfo", response);
        }

        public PartialViewResult GetProfileContactInformation()
        {
            GetDropdownListDataForRegistrationPage();

            var username = Session["username"].ToString();
            var response = new MemberProfileDA().GetProfileContactInformation(username);

            return PartialView("MemberProfile/_ContactInformation", response);
        }

        public PartialViewResult GetProfileAddressInformation()
        {
            GetDropdownListDataForRegistrationPage();

            var username = Session["username"].ToString();
            var response = new MemberProfileDA().GetProfileAddressInformation(username);

            return PartialView("MemberProfile/_AddressInformation", response);
        }

        public PartialViewResult GetProfileCollegeInformation()
        {
            GetDropdownListDataForRegistrationPage();

            var username = Session["username"].ToString();
            var response = new MemberProfileDA().GetProfileCollegeInformation(username);

            return PartialView("MemberProfile/_CollegeInformation", response);
        }

        public PartialViewResult GetProfileWorkplaceAndExpertiseInfo()
        {
            GetDropdownListDataForRegistrationPage();

            var username = Session["username"].ToString();
            var response = new MemberProfileDA().GetProfileWorkplaceAndExpertiseInfo(username);

            return PartialView("MemberProfile/_WorkplaceAndExpertiseInformation", response);
        }



        [HttpPost]
        public bool UpdatePersonalAndLoginInfo(MemberProfileVO profileVo)
        {
            var response = new MemberProfileDA().UpdatePersonalAndLoginInfo(profileVo, Session["username"].ToString());

            if (response >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool UpdateProfileAddressInformation(MemberProfileVO profileVo)
        {
            var response = new MemberProfileDA().UpdateProfileAddressInformation(profileVo, Session["username"].ToString());

            if (response >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool UpdateProfileCollegeInformation(MemberProfileVO profileVo)
        {
            var response = new MemberProfileDA().UpdateProfileCollegeInformation(profileVo, Session["username"].ToString());

            if (response >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool UpdateProfileContactInformation(MemberProfileVO profileVo)
        {
            var response = new MemberProfileDA().UpdateProfileContactInformation(profileVo, Session["username"].ToString());

            if (response >= 1)
                return true;
            else
                return false;
        }

        [HttpPost]
        public bool UpdateProfileWorkplaceAndExpertiseInfo(MemberProfileVO profileVo)
        {
            var response = new MemberProfileDA().UpdateProfileWorkplaceAndExpertiseInfo(profileVo, Session["username"].ToString());

            if (response >= 1)
                return true;
            else
                return false;
        }


        public ActionResult Logout()
        {
            Session.Remove("username");
            return View();
        }

    }
}