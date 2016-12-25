using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.ManageAccess
{
    public class AccessLevelsVO
    {
        public int? AccessID { get; set; }
        public string Page { get; set; }
        public string AccessLevel { get; set; }
        public bool GrantAccess { get; set; }
        public string AccessRole { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}