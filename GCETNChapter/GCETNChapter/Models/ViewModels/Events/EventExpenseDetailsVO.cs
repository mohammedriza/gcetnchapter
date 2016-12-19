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
        public int ExpenseDetailID { get; set; }

        [Display(Name = "* Expense Details")]
        public string ExpenseDetail { get; set; }

        [Display(Name = "* Expense Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? ExpenseDate { get; set; }

        [Display(Name = "* Amount")]
        [DataType(DataType.Currency)]
        public decimal? Amount { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }

    }
}