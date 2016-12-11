using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class MemberProfileDA
    {
        public int UpdatePersonalAndLoginInfo(MemberProfileVO profileVo, string ModifiedBy)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdatePersonalAndLoginInfo(profileVo.Username, profileVo.Password, profileVo.FullName, 
                                                                profileVo.Gender, profileVo.DateOfBirth, profileVo.ProfileImage, ModifiedBy);
            }
            return rowsEffected;
        }

        public int UpdateProfileCollegeInformation(MemberProfileVO profileVo, string ModifiedBy)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdateProfileCollegeInformation(profileVo.Username, profileVo.CollegeRegistrationNo, profileVo.Branch,
                                                                profileVo.EngineeringDescipline, profileVo.Batch, ModifiedBy);
            }
            return rowsEffected;
        }

        public int UpdateProfileContactInformation(MemberProfileVO profileVo, string ModifiedBy)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdateProfileContactInformation(profileVo.Username, profileVo.PrimaryContactNo, profileVo.ContactNoIndia,
                                                                profileVo.WhatsappNumber, profileVo.Email, ModifiedBy);
            }
            return rowsEffected;
        }

        public int UpdateProfileAddressInformation(MemberProfileVO profileVo, string ModifiedBy)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdateProfileAddressInformation(profileVo.Username, profileVo.CurrentAddress, profileVo.CurrentCountry,
                                                                profileVo.PermanentAddress, profileVo.PermanentCountry, ModifiedBy);
            }
            return rowsEffected;
        }

        public int UpdateProfileWorkplaceAndExpertiseInfo(MemberProfileVO profileVo, string ModifiedBy)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdateProfileWorkplaceAndExpertiseInfo(profileVo.Username, profileVo.Company, profileVo.Occupation, profileVo.Interests, profileVo.Expertise1,
                                                                profileVo.Expertise2, profileVo.Expertise3, profileVo.Expertise4, profileVo.Expertise5, ModifiedBy);
            }
            return rowsEffected;
        }


        public MemberProfileVO GetProfileLoginAndPersonalInfo(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetProfileLoginAndPersonalInfo(Username).ToList();

                var profile = new MemberProfileVO()
                {
                    Username = response.ElementAt(0).Username,
                    Password = response.ElementAt(0).Password,
                    ConfirmPassword = response.ElementAt(0).Password,
                    FullName = response.ElementAt(0).FullName,
                    Gender = response.ElementAt(0).Gender,
                    DateOfBirth = Convert.ToDateTime(response.ElementAt(0).DateOfBirth)
                };
                return profile;
            }            
        }


        public MemberProfileVO GetProfileContactInformation(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetProfileContactInformation(Username).ToList();

                var profile = new MemberProfileVO()
                {
                    PrimaryContactNo = response.ElementAt(0).PrimaryContactNo,
                    ContactNoIndia = response.ElementAt(0).ContactNoIndia,
                    WhatsappNumber = response.ElementAt(0).WhatsappNo,
                    Email = response.ElementAt(0).Email
                };
                return profile;
            }
        }


        public MemberProfileVO GetProfileAddressInformation(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetProfileAddressInformation(Username).ToList();

                var profile = new MemberProfileVO()
                {
                    CurrentAddress = response.ElementAt(0).CurrentAddress,
                    CurrentCountry = response.ElementAt(0).CurrentCountry,
                    PermanentAddress = response.ElementAt(0).PermanentAddress,
                    PermanentCountry = response.ElementAt(0).PermanentCountry
                };
                return profile;
            }
        }


        public MemberProfileVO GetProfileCollegeInformation(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetProfileCollegeInformation(Username).ToList();

                var profile = new MemberProfileVO()
                {
                    CollegeRegistrationNo = response.ElementAt(0).CollegeRegistrationNo,
                    Batch = response.ElementAt(0).Batch,
                    Branch = response.ElementAt(0).Branch,
                    EngineeringDescipline = response.ElementAt(0).EngineeringDiscipline
                };
                return profile;
            }
        }


        public MemberProfileVO GetProfileWorkplaceAndExpertiseInfo(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetProfileWorkplaceAndExpertiseInformation(Username).ToList();

                var profile = new MemberProfileVO();

                if (response.Count >= 1)
                {
                    profile.Company = response.ElementAt(0).CompanyName;
                    profile.Occupation = response.ElementAt(0).Occupation;
                    profile.Interests = response.ElementAt(0).Interests;
                    profile.Expertise1 = response.ElementAt(0).Expertise1;
                    profile.Expertise2 = response.ElementAt(0).Expertise2;
                    profile.Expertise3 = response.ElementAt(0).Expertise3;
                    profile.Expertise4 = response.ElementAt(0).Expertise4;
                    profile.Expertise5 = response.ElementAt(0).Expertise5;
                }
                return profile;
            }
        }


    }
}