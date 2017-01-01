using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Members
{
    public class MembersVO
    {
        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Batch")]
        public string Batch { get; set; }

        [Display(Name = "Branch Name")]
        public string Branch { get; set; }

        [Display(Name = "Current Country")]
        public string CurrentCountry { get; set; }

        [Display(Name = "Whatsapp No")]
        public string WhatsappNo { get; set; }

        [Display(Name = "Mobile No")]
        public string PrimaryContactNo { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}