using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels
{
    public class ContactUsVO
    {
        [Display(Name = "* Name")]
        [Required(ErrorMessage = "Please enter your Name.")]
        [StringLength(50, ErrorMessage = "Name should not exceed 50 characters", MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "* Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Please enter your Email.")]
        [StringLength(50, ErrorMessage = "Email should not exceed 50 characters", MinimumLength = 1)]
        public string Email { get; set; }

        [Display(Name = "* Summary")]
        [Required(ErrorMessage = "Please enter quick Summary for your message.")]
        [StringLength(150, ErrorMessage = "Summary should not exceed 150 characters", MinimumLength = 1)]
        public string Summary { get; set; }

        [Display(Name = "* Message")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please type in a detailed message.")]
        [StringLength(5000, ErrorMessage = "Message should not exceed 5000 characters", MinimumLength = 1)]
        public string Messaage { get; set; }

    }
}