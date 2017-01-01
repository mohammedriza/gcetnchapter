using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.News
{
    public class NewsVO
    {
        [Display(Name = "Select an Icon")]
        public string ImageFile { get; set; }

        [Display(Name = "Enter News Headling")]
        public string HeadLine { get; set; }

        [Display(Name = "Enter News Detail")]
        public string NewsDetail { get; set; }

        [Display(Name = "Posted On")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }
    }
}