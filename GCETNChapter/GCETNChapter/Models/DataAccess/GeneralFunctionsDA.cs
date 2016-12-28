using GCETNChapter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class GeneralFunctionsDA
    {
        //---- This method is used to truncate string based on the string value and the number of chars to truncate ---//
        public static string TruncateString(string value, int length)
        {
            if (value.Length > length)
            {
                value = value.Substring(0, length) + "...";
            }
            return value;
        }


        public bool GetAccessLevelAuthorization(int AccessID)
        {
            var LoginInfo = new LoginDetailsVO();
            LoginInfo = (LoginDetailsVO)HttpContext.Current.Session["logininfo"];

            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetAccessLevelAuthorization(AccessID, LoginInfo.AccessRole).FirstOrDefault();
                return Convert.ToBoolean(response);
            }
        }
    }
}