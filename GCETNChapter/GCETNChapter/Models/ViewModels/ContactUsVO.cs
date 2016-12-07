using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels
{
    public class ContactUsVO
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your Name.")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Please enter your Email.")]
        public string Email { get; set; }

        [Display(Name = "A Quick Summary")]
        [Required(ErrorMessage = "Please enter quick Summary for your message.")]
        public string Subject { get; set; }

        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please type in a detailed message.")]
        public string Messaage { get; set; }

    }
}