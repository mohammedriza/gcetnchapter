using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Events
{
    public class EventExpenseDetailsVO
    {
        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [Display(Name = "Expense Detail ID")]
        public int ExpenseDetailsID { get; set; }

        [Display(Name = "* Expense Details")]
        public string ExpenseDetail { get; set; }

        [Display(Name = "* Expense Date")]
        public DateTime ExpenseDate { get; set; }

        [Display(Name = "* Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "ActionUser")]
        public string ActionUser { get; set; }

    }
}