using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.ViewModels.Error
{
    public class ErrorVO
    {
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public string Ex_Message { get; set; }
        public string Ex_InnerException { get; set; }
        public string Ex_Data { get; set; }
        public string Ex_HelpLink { get; set; }
        public int Ex_HResult { get; set; }
        public string Ex_Source { get; set; }
        public string Ex_StackRace { get; set; }
        public string Ex_TargetSite { get; set; }
        public string CreatedBy { get; set; }
        
    }
}