using GCETNChapter.Models.ViewModels.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace GCETNChapter.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public string AddUpdateAdvertisements(AdvertisementVO AdsVo)
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        //--- Upload File to Folder Location ---//
                        var paramDatetime = (DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString());

                        var fileName = string.Format("{0}_{1}", paramDatetime, Path.GetFileName(file.FileName));
                        var path = Path.Combine(Server.MapPath("~/_ImageUploads/Advertisements/"), fileName);
                        file.SaveAs(path);

                        return fileName;
                    }
                    return "Success";
                }
                else
                {
                    return "NoFiles";
                }
            }
            catch(Exception)
            {
                return "Error";
            }
        }




    }
}