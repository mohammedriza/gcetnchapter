using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Advertisement
{
    public class AdvertisementVO
    {
        [Display(Name = "* Title")]
        public string Title { get; set; }

        [Display(Name = "* Body")]
        public string Body { get; set; }

        [Display(Name = "* Select an Image")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Footer")]
        public string Footer { get; set; }
        
    }
}