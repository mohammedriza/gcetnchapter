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
                rowsEffected = db.prcAddUpdateDonationDetails(donationsVo.DonationID, donationsVo.CollegeRegistrationNo, donationsVo.Amount, donationsVo.PaymentReason, donationsVo.PaymentDate,
                                                                donationsVo.PaymentStartDate, donationsVo.PaymentEndDate, donationsVo.CreatedBy);
            }
            return rowsEffected;
        }


        public List<DonationDetailsVO> GetAllDonationDetails()
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var Donations = new List<DonationDetailsVO>();
                var response = db.prcGetDonationDetails(0).ToList();

                if (response.Count > 0)
                {
                    for (int x = 0; x < response.Count; x++)
                    {
                        Donations.Add(new DonationDetailsVO
                        {
                            DonationID = response.ElementAt(x).DonationID,
                            CollegeRegistrationNo = response.ElementAt(x).CollegeRegistrationNo,
                            Amount = response.ElementAt(x).Amount,
                            PaymentReason = response.ElementAt(x).PaymentReason,
                            PaymentDate = response.ElementAt(x).PaymentDate,
                            PaymentStartDate = response.ElementAt(x).PaymentStartDate,
                            PaymentEndDate = response.ElementAt(x).PaymentEndDate,
                            CreatedBy = response.ElementAt(x).CreatedBy,
                            CreatedDate = response.ElementAt(x).CreatedDate,
                            ModifiedBy = response.ElementAt(x).ModifiedBy,
                            ModifiedDate = response.ElementAt(x).ModifiedDate
                        });
                    }
                }
                return Donations;
            }
        }


        public DonationDetailsVO GetDonationDetailsByDonationID(int DonationID)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var Donations = new DonationDetailsVO();
                var response = db.prcGetDonationDetails(DonationID).ToList();

                if (response != null)
                {
                    Donations.DonationID = response.ElementAt(0).DonationID;
                    Donations.CollegeRegistrationNo = response.ElementAt(0).CollegeRegistrationNo;
                    Donations.Amount = response.ElementAt(0).Amount;
                    Donations.PaymentReason = response.ElementAt(0).PaymentReason;
                    Donations.PaymentDate = response.ElementAt(0).PaymentDate;
                    Donations.PaymentStartDate = response.ElementAt(0).PaymentStartDate;
                    Donations.PaymentEndDate = response.ElementAt(0).PaymentEndDate;
                    Donations.CreatedBy = response.ElementAt(0).CreatedBy;
                    Donations.CreatedDate = response.ElementAt(0).CreatedDate;
                    Donations.ModifiedBy = response.ElementAt(0).ModifiedBy;
                    Donations.ModifiedDate = response.ElementAt(0).ModifiedDate;
                }
                return Donations;
            }
        }


        public int DeleteDonations(int DonationID)
        {
            var rowsEffected = 0;

            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcDeleteDonations(DonationID);
            }
            return rowsEffected;
        }
    }
}