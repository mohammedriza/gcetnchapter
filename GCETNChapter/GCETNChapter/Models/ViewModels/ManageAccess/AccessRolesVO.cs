using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.ManageAccess
{
    public class AccessRolesVO
    {
        public string AccessRole { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}