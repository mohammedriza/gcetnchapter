using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Events
{
    public class EventPaymentCollectionVO
    {
        [Display(Name = "Payment ID")]
        public int PaymentCollectionID { get; set; }

        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [Display(Name = "* College Registration No")]
        public string CollegeRegistrationNo { get; set; }

        [Display(Name = "* Expense Date")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "* Aomunt Received")]
        public decimal AmountReceived { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }
    }
}