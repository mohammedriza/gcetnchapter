using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels
{
    public class MemberRegistrationVO
    {
        //-- PERSONAL AND LOGIN INFO --//
        [Display(Name = "Full Name")]
        [StringLength(50, ErrorMessage = "Full Name cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Full Name cannot be blank.")]
        public string FullName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid Date of Birth")]
        [StringLength(10, ErrorMessage = "Date of Birth cannot exceed 10 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Date of Birth cannot be blank.")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Email cannot be blank.")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [StringLength(50, ErrorMessage = "Username should exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Username cannot be blank.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Confirm Password cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Confirm Password cannot be blank.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password should be the same")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Profile Image")]
        [DataType(DataType.ImageUrl)]
        [StringLength(50, ErrorMessage = "Image Filename should exceed 12 characters", MinimumLength = 0)]
        public string ProfileImage { get; set; }

        //-- CONTACT NUMBERS --//
        [Display(Name = "Mobile No")]
        [StringLength(50, ErrorMessage = "Mobile cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Mobile No cannot be blank.")]
        public string MobileNo { get; set; }

        [Display(Name = "Skype ID")]
        [StringLength(50, ErrorMessage = "Skype ID cannot exceed 50 characters", MinimumLength = 0)]
        public string SkypeID { get; set; }

        [Display(Name = "Whatsapp Number")]
        [StringLength(50, ErrorMessage = "Whatsapp Number cannot exceed 50 characters", MinimumLength = 0)]
        public string WhatsappNumber { get; set; }

        //-- OCCUPATION DETAILS --//
        [Display(Name = "Occupation")]
        [StringLength(50, ErrorMessage = "Occupation cannot exceed 50 characters", MinimumLength = 0)]
        public string Occupation { get; set; }

        [Display(Name = "Company")]
        [StringLength(50, ErrorMessage = "Company cannot exceed 50 characters", MinimumLength = 0)]
        public string Company { get; set; }

        [Display(Name = "Activities")]
        [StringLength(150, ErrorMessage = "Activities cannot exceed 150 characters", MinimumLength = 0)]
        public string Activities { get; set; }

        [Display(Name = "Interests")]
        [StringLength(150, ErrorMessage = "Interests cannot exceed 150 characters", MinimumLength = 0)]
        public string Interests { get; set; }

        //-- ADDRESS DETAILS --//
        [Display(Name = "Native Place")]
        [StringLength(50, ErrorMessage = "Native Place cannot exceed 50 characters", MinimumLength = 0)]
        public string NativePlace { get; set; }

        [Display(Name = "Current Address")]
        [StringLength(400, ErrorMessage = "Current Address cannot exceed 400 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Current Address cannot be blank.")]
        public string CurrentAddress { get; set; }
        public string CurrentCountry { get; set; }

        [Display(Name = "Permanent Address")]
        [StringLength(400, ErrorMessage = "Permanent Address cannot exceed 400 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Permanent Address cannot be blank.")]
        public string PermanentAddress { get; set; }
        public string PermanentCountry { get; set; }

        //-- COLLEGE DETAILS --//
        [Display(Name = "College Registration No")]
        [StringLength(12, ErrorMessage = "College Registration No. should exceed 12 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "College Registration No. cannot be blank.")]
        public string CollegeRegistrationNo { get; set; }

        [Display(Name = "Batch")]
        [StringLength(4, ErrorMessage = "Batch cannot exceed 4 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Batch cannot be blank.")]
        public string Batch { get; set; }

        [Display(Name = "Branch")]
        [StringLength(50, ErrorMessage = "Branch cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Branch cannot be blank.")]
        public string Branch { get; set; }

    }
}