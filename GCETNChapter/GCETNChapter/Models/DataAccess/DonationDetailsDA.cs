using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class DonationDetailsDA
    {
        public int AddUpdateDonationDetails(DonationDetailsVO donationsVo)
        {
            var rowsEffected = 0;

            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcAddUpdateDonationDetails(donationsVo.CollegeRegistrationNo, donationsVo.AmountPaid, donationsVo.PaymentReason, donationsVo.PaymentDate, 
                                                                donationsVo.PaymentStartDate, donationsVo.PaymentEndDate, donationsVo.ActionUser);
            }
            return rowsEffected;
        }
    }
}