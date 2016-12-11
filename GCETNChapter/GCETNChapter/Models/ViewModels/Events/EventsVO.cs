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
        public DateTime StartDate { get; set; }

        [Display(Name = "* End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Total Collected Amount")]
        public decimal TotalCollectedAmount { get; set; }

        [Display(Name = "Total Expense Amount")]
        public decimal TotalExpenseAmount { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

    }
}