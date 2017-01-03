using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Advertisement
{
    public class AdvertisementVO
    {
        [Display(Name = "Advertisement ID")]
        public int? AdvertisementID { get; set; }

        [Display(Name = "* Title")]
        public string Title { get; set; }

        [Display(Name = "* Description")]
        public string Description { get; set; }

        [Display(Name = "* Select an Image")]
        public string ImageFileName { get; set; }

        [Display(Name = "Footer")]
        public string Footer { get; set; }

        [Display(Name = "* Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "* End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? ModifiedDate { get; set; }
    }
}