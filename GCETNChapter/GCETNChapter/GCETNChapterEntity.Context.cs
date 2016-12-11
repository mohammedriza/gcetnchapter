﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GCETNChapter
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GCE_TN_ChapterEntities : DbContext
    {
        public GCE_TN_ChapterEntities()
            : base("name=GCE_TN_ChapterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<prcGetCountryList_Result> prcGetCountryList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prcGetCountryList_Result>("prcGetCountryList");
        }
    
        public virtual ObjectResult<prcGetGenderList_Result> prcGetGenderList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prcGetGenderList_Result>("prcGetGenderList");
        }
    
        public virtual ObjectResult<prcGetBranchList_Result> prcGetBranchList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prcGetBranchList_Result>("prcGetBranchList");
        }
    
        public virtual int prcInsertContactUsInfo(string name, string email, string summary, string message)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var summaryParameter = summary != null ?
                new ObjectParameter("Summary", summary) :
                new ObjectParameter("Summary", typeof(string));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prcInsertContactUsInfo", nameParameter, emailParameter, summaryParameter, messageParameter);
        }
    
        public virtual int prcRegisterNewOrUpdateMember(string username, string password, string collegeRegistrationNo, string fullName, string gender, Nullable<System.DateTime> dateOfBirth, string branch, string engineeringDiscipline, Nullable<System.DateTime> memberJoinedDate, string batch, string primaryContactNo, string contactNoIndia, string whatsappNo, string email, string permanentAddress, string permanentCountry, string currentAddress, string currentCountry, string profileImage, string lastModifiedBy)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var collegeRegistrationNoParameter = collegeRegistrationNo != null ?
                new ObjectParameter("CollegeRegistrationNo", collegeRegistrationNo) :
                new ObjectParameter("CollegeRegistrationNo", typeof(string));
    
            var fullNameParameter = fullName != null ?
                new ObjectParameter("FullName", fullName) :
                new ObjectParameter("FullName", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            var branchParameter = branch != null ?
                new ObjectParameter("Branch", branch) :
                new ObjectParameter("Branch", typeof(string));
    
            var engineeringDisciplineParameter = engineeringDiscipline != null ?
                new ObjectParameter("EngineeringDiscipline", engineeringDiscipline) :
                new ObjectParameter("EngineeringDiscipline", typeof(string));
    
            var memberJoinedDateParameter = memberJoinedDate.HasValue ?
                new ObjectParameter("MemberJoinedDate", memberJoinedDate) :
                new ObjectParameter("MemberJoinedDate", typeof(System.DateTime));
    
            var batchParameter = batch != null ?
                new ObjectParameter("Batch", batch) :
                new ObjectParameter("Batch", typeof(string));
    
            var primaryContactNoParameter = primaryContactNo != null ?
                new ObjectParameter("PrimaryContactNo", primaryContactNo) :
                new ObjectParameter("PrimaryContactNo", typeof(string));
    
            var contactNoIndiaParameter = contactNoIndia != null ?
                new ObjectParameter("ContactNoIndia", contactNoIndia) :
                new ObjectParameter("ContactNoIndia", typeof(string));
    
            var whatsappNoParameter = whatsappNo != null ?
                new ObjectParameter("WhatsappNo", whatsappNo) :
                new ObjectParameter("WhatsappNo", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var permanentAddressParameter = permanentAddress != null ?
                new ObjectParameter("PermanentAddress", permanentAddress) :
                new ObjectParameter("PermanentAddress", typeof(string));
    
            var permanentCountryParameter = permanentCountry != null ?
                new ObjectParameter("PermanentCountry", permanentCountry) :
                new ObjectParameter("PermanentCountry", typeof(string));
    
            var currentAddressParameter = currentAddress != null ?
                new ObjectParameter("CurrentAddress", currentAddress) :
                new ObjectParameter("CurrentAddress", typeof(string));
    
            var currentCountryParameter = currentCountry != null ?
                new ObjectParameter("CurrentCountry", currentCountry) :
                new ObjectParameter("CurrentCountry", typeof(string));
    
            var profileImageParameter = profileImage != null ?
                new ObjectParameter("ProfileImage", profileImage) :
                new ObjectParameter("ProfileImage", typeof(string));
    
            var lastModifiedByParameter = lastModifiedBy != null ?
                new ObjectParameter("LastModifiedBy", lastModifiedBy) :
                new ObjectParameter("LastModifiedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prcRegisterNewOrUpdateMember", usernameParameter, passwordParameter, collegeRegistrationNoParameter, fullNameParameter, genderParameter, dateOfBirthParameter, branchParameter, engineeringDisciplineParameter, memberJoinedDateParameter, batchParameter, primaryContactNoParameter, contactNoIndiaParameter, whatsappNoParameter, emailParameter, permanentAddressParameter, permanentCountryParameter, currentAddressParameter, currentCountryParameter, profileImageParameter, lastModifiedByParameter);
        }
    
        public virtual ObjectResult<string> prcCheckIfCollegeRegNoExist(string collegeRegistrationNo)
        {
            var collegeRegistrationNoParameter = collegeRegistrationNo != null ?
                new ObjectParameter("CollegeRegistrationNo", collegeRegistrationNo) :
                new ObjectParameter("CollegeRegistrationNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("prcCheckIfCollegeRegNoExist", collegeRegistrationNoParameter);
        }
    
        public virtual int prcUpdatePersonalAndLoginInfo(string username, string password, string fullName, string gender, Nullable<System.DateTime> dateOfBirth, string profileImage, string lastModifiedBy)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var fullNameParameter = fullName != null ?
                new ObjectParameter("FullName", fullName) :
                new ObjectParameter("FullName", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            var profileImageParameter = profileImage != null ?
                new ObjectParameter("ProfileImage", profileImage) :
                new ObjectParameter("ProfileImage", typeof(string));
    
            var lastModifiedByParameter = lastModifiedBy != null ?
                new ObjectParameter("LastModifiedBy", lastModifiedBy) :
                new ObjectParameter("LastModifiedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prcUpdatePersonalAndLoginInfo", usernameParameter, passwordParameter, fullNameParameter, genderParameter, dateOfBirthParameter, profileImageParameter, lastModifiedByParameter);
        }
    
        public virtual ObjectResult<prcGetProfileLoginAndPersonalInfo_Result> prcGetProfileLoginAndPersonalInfo(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prcGetProfileLoginAndPersonalInfo_Result>("prcGetProfileLoginAndPersonalInfo", usernameParameter);
        }
    
        public virtual ObjectResult<prcGetProfileAddressInformation_Result> prcGetProfileAddressInformation(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prcGetProfileAddressInformation_Result>("prcGetProfileAddressInformation", usernameParameter);
        }
    
        public virtual ObjectResult<prcGetProfileCollegeInformation_Result> prcGetProfileCollegeInformation(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prcGetProfileCollegeInformation_Result>("prcGetProfileCollegeInformation", usernameParameter);
        }
    
        public virtual ObjectResult<prcGetProfileContactInformation_Result> prcGetProfileContactInformation(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prcGetProfileContactInformation_Result>("prcGetProfileContactInformation", usernameParameter);
        }
    
        public virtual ObjectResult<prcGetProfileWorkplaceAndExpertiseInformation_Result> prcGetProfileWorkplaceAndExpertiseInformation(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<prcGetProfileWorkplaceAndExpertiseInformation_Result>("prcGetProfileWorkplaceAndExpertiseInformation", usernameParameter);
        }
    
        public virtual ObjectResult<string> prcCheckIfUsernameExist(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("prcCheckIfUsernameExist", usernameParameter);
        }
    
        public virtual int prcUpdateProfileAddressInformation(string username, string currentAddress, string currentCountry, string permanentAddress, string permanentCountry, string lastModifiedBy)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var currentAddressParameter = currentAddress != null ?
                new ObjectParameter("CurrentAddress", currentAddress) :
                new ObjectParameter("CurrentAddress", typeof(string));
    
            var currentCountryParameter = currentCountry != null ?
                new ObjectParameter("CurrentCountry", currentCountry) :
                new ObjectParameter("CurrentCountry", typeof(string));
    
            var permanentAddressParameter = permanentAddress != null ?
                new ObjectParameter("PermanentAddress", permanentAddress) :
                new ObjectParameter("PermanentAddress", typeof(string));
    
            var permanentCountryParameter = permanentCountry != null ?
                new ObjectParameter("PermanentCountry", permanentCountry) :
                new ObjectParameter("PermanentCountry", typeof(string));
    
            var lastModifiedByParameter = lastModifiedBy != null ?
                new ObjectParameter("LastModifiedBy", lastModifiedBy) :
                new ObjectParameter("LastModifiedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prcUpdateProfileAddressInformation", usernameParameter, currentAddressParameter, currentCountryParameter, permanentAddressParameter, permanentCountryParameter, lastModifiedByParameter);
        }
    
        public virtual int prcUpdateProfileCollegeInformation(string username, string collegeRegistrationNo, string branch, string engineeringDiscipline, string batch, string lastModifiedBy)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var collegeRegistrationNoParameter = collegeRegistrationNo != null ?
                new ObjectParameter("CollegeRegistrationNo", collegeRegistrationNo) :
                new ObjectParameter("CollegeRegistrationNo", typeof(string));
    
            var branchParameter = branch != null ?
                new ObjectParameter("Branch", branch) :
                new ObjectParameter("Branch", typeof(string));
    
            var engineeringDisciplineParameter = engineeringDiscipline != null ?
                new ObjectParameter("EngineeringDiscipline", engineeringDiscipline) :
                new ObjectParameter("EngineeringDiscipline", typeof(string));
    
            var batchParameter = batch != null ?
                new ObjectParameter("Batch", batch) :
                new ObjectParameter("Batch", typeof(string));
    
            var lastModifiedByParameter = lastModifiedBy != null ?
                new ObjectParameter("LastModifiedBy", lastModifiedBy) :
                new ObjectParameter("LastModifiedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prcUpdateProfileCollegeInformation", usernameParameter, collegeRegistrationNoParameter, branchParameter, engineeringDisciplineParameter, batchParameter, lastModifiedByParameter);
        }
    
        public virtual int prcUpdateProfileContactInformation(string username, string primaryContactNo, string contactNoIndia, string whatsappNo, string email, string lastModifiedBy)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var primaryContactNoParameter = primaryContactNo != null ?
                new ObjectParameter("PrimaryContactNo", primaryContactNo) :
                new ObjectParameter("PrimaryContactNo", typeof(string));
    
            var contactNoIndiaParameter = contactNoIndia != null ?
                new ObjectParameter("ContactNoIndia", contactNoIndia) :
                new ObjectParameter("ContactNoIndia", typeof(string));
    
            var whatsappNoParameter = whatsappNo != null ?
                new ObjectParameter("WhatsappNo", whatsappNo) :
                new ObjectParameter("WhatsappNo", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var lastModifiedByParameter = lastModifiedBy != null ?
                new ObjectParameter("LastModifiedBy", lastModifiedBy) :
                new ObjectParameter("LastModifiedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prcUpdateProfileContactInformation", usernameParameter, primaryContactNoParameter, contactNoIndiaParameter, whatsappNoParameter, emailParameter, lastModifiedByParameter);
        }
    
        public virtual int prcUpdateProfileWorkplaceAndExpertiseInfo(string username, string companyName, string occupation, string interests, string expertise1, string expertise2, string expertise3, string expertise4, string expertise5, string lastModifiedBy)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var companyNameParameter = companyName != null ?
                new ObjectParameter("CompanyName", companyName) :
                new ObjectParameter("CompanyName", typeof(string));
    
            var occupationParameter = occupation != null ?
                new ObjectParameter("Occupation", occupation) :
                new ObjectParameter("Occupation", typeof(string));
    
            var interestsParameter = interests != null ?
                new ObjectParameter("Interests", interests) :
                new ObjectParameter("Interests", typeof(string));
    
            var expertise1Parameter = expertise1 != null ?
                new ObjectParameter("Expertise1", expertise1) :
                new ObjectParameter("Expertise1", typeof(string));
    
            var expertise2Parameter = expertise2 != null ?
                new ObjectParameter("Expertise2", expertise2) :
                new ObjectParameter("Expertise2", typeof(string));
    
            var expertise3Parameter = expertise3 != null ?
                new ObjectParameter("Expertise3", expertise3) :
                new ObjectParameter("Expertise3", typeof(string));
    
            var expertise4Parameter = expertise4 != null ?
                new ObjectParameter("Expertise4", expertise4) :
                new ObjectParameter("Expertise4", typeof(string));
    
            var expertise5Parameter = expertise5 != null ?
                new ObjectParameter("Expertise5", expertise5) :
                new ObjectParameter("Expertise5", typeof(string));
    
            var lastModifiedByParameter = lastModifiedBy != null ?
                new ObjectParameter("LastModifiedBy", lastModifiedBy) :
                new ObjectParameter("LastModifiedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prcUpdateProfileWorkplaceAndExpertiseInfo", usernameParameter, companyNameParameter, occupationParameter, interestsParameter, expertise1Parameter, expertise2Parameter, expertise3Parameter, expertise4Parameter, expertise5Parameter, lastModifiedByParameter);
        }
    
        public virtual int prcAddUpdateDonationDetails(string collegeRegistrationNo, Nullable<decimal> amount, string paymentReason, Nullable<System.DateTime> paymentDate, Nullable<System.DateTime> paymentStartDate, Nullable<System.DateTime> paymentEndDate, string username)
        {
            var collegeRegistrationNoParameter = collegeRegistrationNo != null ?
                new ObjectParameter("CollegeRegistrationNo", collegeRegistrationNo) :
                new ObjectParameter("CollegeRegistrationNo", typeof(string));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(decimal));
    
            var paymentReasonParameter = paymentReason != null ?
                new ObjectParameter("PaymentReason", paymentReason) :
                new ObjectParameter("PaymentReason", typeof(string));
    
            var paymentDateParameter = paymentDate.HasValue ?
                new ObjectParameter("PaymentDate", paymentDate) :
                new ObjectParameter("PaymentDate", typeof(System.DateTime));
    
            var paymentStartDateParameter = paymentStartDate.HasValue ?
                new ObjectParameter("PaymentStartDate", paymentStartDate) :
                new ObjectParameter("PaymentStartDate", typeof(System.DateTime));
    
            var paymentEndDateParameter = paymentEndDate.HasValue ?
                new ObjectParameter("PaymentEndDate", paymentEndDate) :
                new ObjectParameter("PaymentEndDate", typeof(System.DateTime));
    
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("prcAddUpdateDonationDetails", collegeRegistrationNoParameter, amountParameter, paymentReasonParameter, paymentDateParameter, paymentStartDateParameter, paymentEndDateParameter, usernameParameter);
        }
    }
}