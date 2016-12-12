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
        public int EventID { get; set; }

        [Display(Name = "* Image")]
        public string Image { get; set; }

        [Display(Name = "ActionUser")]
        public string ActionUser { get; set; }
    }
}