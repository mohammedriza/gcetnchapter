using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels
{
    public class MemberProfileVO
    {
        //-- PERSONAL AND LOGIN INFO --//
        [Display(Name = "* Full Name")]
        [StringLength(50, ErrorMessage = "Full Name cannot exceed 50 characters.", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter your Full Name")]
        public string FullName { get; set; }

        [Display(Name = "* Gender")]
        [Required(ErrorMessage = "Please Select a Gender.")]
        public string Gender { get; set; }

        [Display(Name = "* Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid Date of Birth.")]
        [Required(ErrorMessage = "Please select your Date of Birth.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "* Username")]
        [StringLength(50, ErrorMessage = "Username should exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter Username")]
        public string Username { get; set; }

        [Display(Name = "* Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a strong Password.")]
        public string Password { get; set; }

        [Display(Name = "* Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Confirm Password cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Confirm Password cannot be blank.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Profile Image")]
        [DataType(DataType.ImageUrl)]
        [StringLength(50, ErrorMessage = "Image Filename should not exceed 50 characters", MinimumLength = 0)]
        public string ProfileImage { get; set; }

        [Display(Name = "Member Joined Date")]
        public DateTime? MemberJoinedDate { get; set; }


        //-- CONTACT NUMBERS --//
        [Display(Name = "* Primary Contact No")]
        [StringLength(15, ErrorMessage = "Primary Contact No should not exceed 15 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter your Primary Contact Number.")]
        public string PrimaryContactNo { get; set; }

        [Display(Name = "* Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter your Email address.")]
        public string Email { get; set; }

        [Display(Name = "Contact No in India")]
        [StringLength(15, ErrorMessage = "Contact No in India should not exceed 15 characters", MinimumLength = 0)]
        public string ContactNoIndia { get; set; }

        [Display(Name = "Whatsapp Number")]
        [StringLength(15, ErrorMessage = "Whatsapp Number should not exceed 15 characters", MinimumLength = 0)]
        public string WhatsappNumber { get; set; }


        //-- ADDRESS DETAILS --//
        [Display(Name = "* Current Address")]
        [StringLength(400, ErrorMessage = "Current Address cannot exceed 400 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter your Current Address.")]
        public string CurrentAddress { get; set; }
        public string CurrentCountry { get; set; }

        [Display(Name = "* Permanent Address")]
        [StringLength(400, ErrorMessage = "Permanent Address cannot exceed 400 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter your Permanent Address.")]
        public string PermanentAddress { get; set; }
        public string PermanentCountry { get; set; }


        //-- COLLEGE DETAILS --//
        [Display(Name = "* College Registration No")]
        [StringLength(12, ErrorMessage = "College Registration No. should not exceed 12 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter your College Registration No.")]
        public string CollegeRegistrationNo { get; set; }

        [Display(Name = "* Batch")]
        [StringLength(4, ErrorMessage = "Batch should not exceed 4 characters", MinimumLength = 1)]
        [Required(ErrorMessage = "Please select your Batch from the list.")]
        public string Batch { get; set; }

        [Display(Name = "* Branch")]
        [StringLength(50, ErrorMessage = "Branch cannot exceed 50 characters.", MinimumLength = 1)]
        [Required(ErrorMessage = "Please select a Branch.")]
        public string Branch { get; set; }

        [Display(Name = "Engineering Discipline")]
        [StringLength(150, ErrorMessage = "Engineering Discipline should not exceed 150 characters.", MinimumLength = 0)]
        public string EngineeringDescipline { get; set; }


        //-- OCCUPATION DETAILS --//
        [Display(Name = "Occupation")]
        [StringLength(50, ErrorMessage = "Occupation should not exceed 50 characters", MinimumLength = 0)]
        public string Occupation { get; set; }

        [Display(Name = "* Company")]
        [StringLength(50, ErrorMessage = "Company should not exceed 50 characters", MinimumLength = 0)]
        public string Company { get; set; }

        [Display(Name = "Expertise Areas")]
        [StringLength(150, ErrorMessage = "Activities should not exceed 150 characters", MinimumLength = 0)]
        public string Expertise1 { get; set; }

        [StringLength(150, ErrorMessage = "Activities should not exceed 150 characters", MinimumLength = 0)]
        public string Expertise2 { get; set; }

        [StringLength(150, ErrorMessage = "Activities should not exceed 150 characters", MinimumLength = 0)]
        public string Expertise3 { get; set; }

        [StringLength(150, ErrorMessage = "Activities should not exceed 150 characters", MinimumLength = 0)]
        public string Expertise4 { get; set; }

        [StringLength(150, ErrorMessage = "Activities should not exceed 150 characters", MinimumLength = 0)]
        public string Expertise5 { get; set; }

        [Display(Name = "Interests")]
        [StringLength(150, ErrorMessage = "Interests cannot exceed 150 characters", MinimumLength = 0)]
        public string Interests { get; set; }

        public string ActionUser { get; set; }
    }
}