using GCETNChapter.Models.ViewModels.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class ErrorDA
    {
        public void BuildErrorDetails(Exception ex, string Controller, string ActionName)
        {
            var createdBy = "";
            if (HttpContext.Current.Session["username"] == null)
                createdBy = "SYSTEM";
            else
                createdBy = HttpContext.Current.Session["username"].ToString();

            var Error = new ErrorVO()
            {
                Controller = Controller,
                ActionName = ActionName,
                Ex_Data = "",
                Ex_HelpLink = "",
                Ex_HResult = 0,
                Ex_InnerException = string.Format("Message: {0} | InnerException: {1}", ex.InnerException.Message, ex.InnerException.InnerException),
                Ex_Message = ex.Message,
                Ex_Source = ex.Source,
                Ex_StackRace = ex.StackTrace,
                Ex_TargetSite = ex.TargetSite.Name,
                CreatedBy = createdBy
            };

            var rowsEffected = LogErrors(Error);
        }

        public int LogErrors(ErrorVO Error)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcAddErrorLogEntry(Error.Controller, Error.ActionName, Error.Ex_Message, Error.Ex_InnerException, Error.Ex_Data, 
                                                     Error.Ex_HelpLink, Error.Ex_HResult, Error.Ex_Source, Error.Ex_StackRace, Error.Ex_TargetSite, Error.CreatedBy);

                return response;
            }
        }

    }
}