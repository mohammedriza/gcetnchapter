using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.News
{
    public class NewsVO
    {
        public int? NewsID { get; set; }

        [Display(Name = "Choose Image")]
        public string ImageFile { get; set; }

        [Display(Name = "News Headline")]
        public string HeadLine { get; set; }

        [Display(Name = "News Detail")]
        public string NewsDetail { get; set; }

        public string CreatedBy { get; set; }
        
        [Display(Name = "Posted On")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }
    }
}