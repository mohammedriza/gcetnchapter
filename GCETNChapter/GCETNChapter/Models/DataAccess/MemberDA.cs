using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class MemberDA
    {
        public LoginDetailsVO AuthenticateMember(string Username, string Password)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var loginDtls = new LoginDetailsVO();
                var response = db.prcGetAuthenticationDetails(Username, Password).ToList();

                if (response.Count >= 1)
                {
                    loginDtls.AccessRole = response.ElementAt(0).AccessRole;
                    loginDtls.AccountStatus = response.ElementAt(0).AccountStatus;
                    loginDtls.CollegeRegistrationNo = response.ElementAt(0).CollegeRegistrationNo;
                    loginDtls.FullName = response.ElementAt(0).FullName;

                    return loginDtls;
                }
                return null;
            }
        }


        public static List<string> GetCountryList()
        {
            var countryList = new List<string>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetCountryList().ToList();

                if (response.Count >= 1)
                {
                    countryList.Add("-- Select Country --");
                    for (int i = 0; i < response.Count; i++)
                    {
                        countryList.Add(response.ElementAt(i).Country);
                    }
                }
            }
            return countryList;
        }


        public static List<string> GetGenderList()
        {
            var genderList = new List<string>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetGenderList().ToList();

                if (response.Count >= 1)
                {
                    genderList.Add("-- Select Gender --");
                    for (int i = 0; i < response.Count; i++)
                    {
                        genderList.Add(response.ElementAt(i).Gender);
                    }
                }
            }
            return genderList;
        }


        public static List<string> GetBranchList()
        {
            var branchList = new List<string>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetBranchList().ToList();

                if (response.Count >= 1)
                {
                    branchList.Add("-- Select Branch --");
                    for (int i = 0; i < response.Count; i++)
                    {
                        branchList.Add(response.ElementAt(i).Branch);
                    }
                }
            }
            return branchList;
        }


        public static List<string> GetBatchList()
        {
            var startYear = 1980;
            var endYear = DateTime.Now.Year;
            var yearsCount = endYear - startYear;

            var BatchList = new List<string>();
            BatchList.Add("-- Select Batch --");

            for (int x = 0; x <= yearsCount; x++)
            {
                BatchList.Add((startYear + x).ToString());
            }

            return BatchList;
        }


        public int RegisterNewMemberInRegistrationPage(MemberRegistrationVO RegDetails)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcRegisterNewOrUpdateMember(RegDetails.Username, RegDetails.Password, RegDetails.CollegeRegistrationNo, RegDetails.FullName, RegDetails.Gender, RegDetails.DateOfBirth, 
                                                                RegDetails.Branch, RegDetails.EngineeringDescipline, RegDetails.MemberJoinedDate, RegDetails.Batch, RegDetails.PrimaryContactNo,
                                                                RegDetails.ContactNoIndia, RegDetails.WhatsappNumber, RegDetails.Email, RegDetails.PermanentAddress, RegDetails.PermanentCountry,
                                                                RegDetails.CurrentAddress, RegDetails.CurrentCountry, RegDetails.ProfileImage, HttpContext.Current.Session["username"].ToString());
            }

            return rowsEffected;
        }


        public static string CheckIfCollegeRegNoExist(string CollegeRegistrationNo)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var result= db.prcCheckIfCollegeRegNoExist(CollegeRegistrationNo).FirstOrDefault();

                return result;
            }            
        }


        public static string CheckIfUsernameExist(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var result = db.prcCheckIfUsernameExist(Username).FirstOrDefault();

                return result;
            }
        }
    }
}