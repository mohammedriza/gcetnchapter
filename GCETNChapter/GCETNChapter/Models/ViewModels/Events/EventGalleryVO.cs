using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Events
{
    public class EventGalleryVO
    {
        [Display(Name = "Event ID")]
        public int? EventID { get; set; }

        [Display(Name = "* Event Name")]
        public string EventName { get; set; }

        [Display(Name = "* Event")]
        public List<string> EventNameList { get; set; }

        [Display(Name = "Image ID")]
        public int? ImageID { get; set; }
        
        [Display(Name = "* Image")]
        public string ImageFileName { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }
    }
}