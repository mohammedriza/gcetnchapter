using GCETNChapter.Models.ViewModels;
using GCETNChapter.Models.ViewModels.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class MemberProfileDA
    {
        public int UpdatePersonalAndLoginInfo(MemberProfileVO profileVo)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdatePersonalAndLoginInfo(profileVo.Username, profileVo.Password, profileVo.FullName, 
                                                                profileVo.Gender, profileVo.DateOfBirth, profileVo.ProfileImage, profileVo.ActionUser);
            }
            return rowsEffected;
        }

        public int UpdateProfileCollegeInformation(MemberProfileVO profileVo)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdateProfileCollegeInformation(profileVo.Username, profileVo.CollegeRegistrationNo, profileVo.Branch,
                                                                profileVo.EngineeringDescipline, profileVo.Batch, profileVo.ActionUser);
            }
            return rowsEffected;
        }

        public int UpdateProfileContactInformation(MemberProfileVO profileVo)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdateProfileContactInformation(profileVo.Username, profileVo.PrimaryContactNo, profileVo.ContactNoIndia,
                                                                profileVo.WhatsappNumber, profileVo.Email, profileVo.ActionUser);
            }
            return rowsEffected;
        }

        public int UpdateProfileAddressInformation(MemberProfileVO profileVo)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdateProfileAddressInformation(profileVo.Username, profileVo.CurrentAddress, profileVo.CurrentCountry,
                                                                profileVo.PermanentAddress, profileVo.PermanentCountry, profileVo.ActionUser);
            }
            return rowsEffected;
        }

        public int UpdateProfileWorkplaceAndExpertiseInfo(MemberProfileVO profileVo)
        {
            int rowsEffected = 0;
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcUpdateProfileWorkplaceAndExpertiseInfo(profileVo.Username, profileVo.Company, profileVo.Occupation, profileVo.Interests, profileVo.Expertise1,
                                                                profileVo.Expertise2, profileVo.Expertise3, profileVo.Expertise4, profileVo.Expertise5, profileVo.ActionUser);
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


        //************************************************--- MANAGE USER METHODS ---************************************************//

        public List<string> GetUserAccountStatusList()
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.Database.SqlQuery<string>("SELECT AccountStatus FROM TBL_AccountStatus").ToList();
                response.Insert(0, "-- Select Account Status --");
                return response;
            }
        }

        public List<string> GetUserAccessRoleList()
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.Database.SqlQuery<string>("SELECT AccessRole FROM dbo.TBL_AccessRoles").ToList();
                response.Insert(0, "-- Select Access Role --");
                return response;
            }
        }

        public List<UserVO> GetUsersDetails(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var users = new List<UserVO>();
                var response = db.prcGetUserDetails(Username).ToList();

                for (int x=0;x<response.Count;x++)
                {
                    users.Add(new UserVO()
                    {
                        Username=response.ElementAt(x).Username,
                        Password = response.ElementAt(x).Password,
                        CollegeRegistrationNo = response.ElementAt(x).CollegeRegistrationNo,
                        AccessRole = response.ElementAt(x).AccessRole,
                        AccountStatus = response.ElementAt(x).AccountStatus,
                        CreatedBy = response.ElementAt(x).CreatedBy,
                        CreatedDate = response.ElementAt(x).CreatedDate,
                        ModifiedBy = response.ElementAt(x).ModifiedBy,
                        ModifiedDate = response.ElementAt(x).ModifiedDate
                    });
                }
                return users;
            }
        }


        public UserVO GetUsersDetailsByUserID(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetUserDetails(Username).ToList();

                var users = new UserVO()
                {
                    Username = response.ElementAt(0).Username,
                    Password = response.ElementAt(0).Password,
                    ConfirmPassword = response.ElementAt(0).Password,
                    CollegeRegistrationNo = response.ElementAt(0).CollegeRegistrationNo,
                    AccessRole = response.ElementAt(0).AccessRole,
                    AccountStatus = response.ElementAt(0).AccountStatus,
                    CreatedBy = response.ElementAt(0).CreatedBy,
                    CreatedDate = response.ElementAt(0).CreatedDate,
                    ModifiedBy = response.ElementAt(0).ModifiedBy,
                    ModifiedDate = response.ElementAt(0).ModifiedDate
                };
                return users;
            }
        }


        public int CreateUpdateUserDetails(UserVO Users)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var rowsEffected = db.prcCreateUpdateUserDetails(Users.Username, Users.Password, Users.CollegeRegistrationNo, Users.AccessRole, Users.AccountStatus, Users.CreatedBy);
                return rowsEffected;
            }
        }


        public int DeleteUserAccount(string Username)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var rowsEffected = db.prcDeleteUserAccount(Username);
                return rowsEffected;
            }
        }


        public List<MembersVO> GetAllMembers()
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var result = db.Database.SqlQuery<MembersVO>("SELECT FullName, Branch, Batch, PrimaryContactNo, WhatsappNo, Email, CurrentCountry, ProfileImage FROM GCE_MemberInfo").ToList();
                return result;
            }
        }

    }
}