using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Events
{
    public class EventPaymentCollectionVO
    {
        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [Display(Name = "* College Registration No")]
        public string CollegeRegistrationNo { get; set; }

        [Display(Name = "* Expense Date")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "* Aomunt Received")]
        public decimal AomuntReceived { get; set; }

        [Display(Name = "ActionUser")]
        public string ActionUser { get; set; }
    }
}