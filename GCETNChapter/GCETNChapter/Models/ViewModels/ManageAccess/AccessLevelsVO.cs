using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.ManageAccess
{
    public class AccessLevelsVO
    {
        [Display(Name = "Access ID")]
        public int? AccessID { get; set; }

        [Display(Name = "Page")]
        public string Page { get; set; }

        [Display(Name = "Access Level")]
        public string AccessLevel { get; set; }

        [Display(Name = "Grant Access")]
        public bool GrantAccess { get; set; }

        [Display(Name = "Access Role")]
        public string AccessRole { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

    }
}