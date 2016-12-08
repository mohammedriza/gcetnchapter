using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class HomeDA
    {
        public int InsertContactUsDetails(ContactUsVO contactUs)
        {
            var rowsEffected = 0;

            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                rowsEffected = db.prcInsertContactUsInfo(contactUs.Name, contactUs.Email, contactUs.Summary, contactUs.Messaage);
            }
            return rowsEffected;
        }
    }
}