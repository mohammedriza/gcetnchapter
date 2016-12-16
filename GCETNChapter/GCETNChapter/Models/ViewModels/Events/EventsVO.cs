using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Events
{
    public class EventsVO
    {
        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [Display(Name = "* Event Name")]
        public string EventName { get; set; }

        [Display(Name = "* Start Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid Start Date.")]
        [Required(ErrorMessage = "Please select the Start Date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "* End Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid End Date.")]
        [Required(ErrorMessage = "Please select the End Date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Total Collected Amount")]
        [DataType(DataType.Currency)]
        public decimal TotalCollectedAmount { get; set; }

        [Display(Name = "Total Expense Amount")]
        [DataType(DataType.Currency)]
        public decimal TotalExpenseAmount { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }

    }
}