using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels
{
    public class DonationDetailsVO
    {
        [Display(Name = "* College Registration No")]
        [StringLength(12, ErrorMessage = "College Registration No should not exceed 12 characters.", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a valid College Registration No.")]
        public string CollegeRegistrationNo { get; set; }

        [Display(Name = "* Payment Reason")]
        [StringLength(100, ErrorMessage = "Payment Reason should not exceed 100 characters.", MinimumLength = 1)]
        [Required(ErrorMessage = "Please enter a valid Payment Reason.")]
        public string PaymentReason { get; set; }

        [Display(Name = "* Payment Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a valid Payment Date.")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "* Payment Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a valid Payment Start Date.")]
        public DateTime PaymentStartDate { get; set; }

        [Display(Name = "* Payment End Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a valid Payment End Date.")]
        public DateTime PaymentEndDate { get; set; }

        [Display(Name = "* Amount Paid")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please enter a valid Amount.")]
        public decimal AmountPaid { get; set; }

        [Display(Name = "* Last Modified By")]
        public string ActionUser { get; set; }

    }
}