//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GCETNChapter
{
    using System;
    
    public partial class prcGetDonationDetails_Result
    {
        public int DonationID { get; set; }
        public string CollegeRegistrationNo { get; set; }
        public decimal Amount { get; set; }
        public string PaymentReason { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public System.DateTime PaymentStartDate { get; set; }
        public System.DateTime PaymentEndDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}