using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels
{
    public class UserVO
    {
        [Display(Name = "* Username")]
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
        [Compare("Password", ErrorMessage = "Password and Confirm Password should be the same")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "* College Reg No")]
        public string CollegeRegistrationNo { get; set; }

        [Display(Name = "* Access Role")]
        public string AccessRole { get; set; }
        public List<string> AccessRoleList { get; set; }

        [Display(Name = "* Account Status")]
        public string AccountStatus { get; set; }
        public List<string> AccountStatusList { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }
    }
}