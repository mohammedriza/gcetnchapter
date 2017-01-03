using GCETNChapter.Models.ViewModels.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using GCETNChapter.Models.DataAccess;

namespace GCETNChapter.Controllers
{
    public class AdvertisementController : Controller
    {
        //--- CHECK IF USER'S SESSION EXIST. ELSE REDIRECT TO HOME PAGE ---//
        private void CheckSessionStatus()
        {
            if (Session["username"] == null)
                Response.Redirect("~/Home/Index/");
        }


        // GET: Advertisement
        public ActionResult Index()
        {
            CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

            return View();
        }


        [HttpPost]
        public string AddUpdateAdvertisements(AdvertisementVO AdsVo)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

                if (AdsVo.StartDate > AdsVo.ExpiryDate)
                    return "InvalidDate";
                else if (Request.Files.Count > 0)
                {
                    //--- UPLOAD IMAGES TO SHARED LOCATION ---//
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        //--- Upload File to Folder Location ---//
                        var paramDatetime = (DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString());

                        AdsVo.ImageFileName = string.Format("{0}_{1}", paramDatetime, Path.GetFileName(file.FileName));
                        var path = Path.Combine(Server.MapPath("~/_ImageUploads/Advertisements/"), AdsVo.ImageFileName);
                        file.SaveAs(path);
                    }

                    //--- INSERT DATA TO DATABASE TABLE ---//
                    AdsVo.CreatedBy = Session["username"].ToString();
                    var rowsEffected = new AdvertisementDA().AddUpdateAdvertisements(AdsVo);

                    if (rowsEffected >= 1)
                        return AdsVo.ImageFileName;
                    else
                        return "Error";
                }
                else
                {
                    return "NoFiles";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }


        public PartialViewResult GetAllAdvertisements(int AdID)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

                if (AdID == 0)
                {
                    var AdList = new AdvertisementDA().GetAllAdvertisements();
                    return PartialView("_ViewAdvertisements", AdList);
                }
                else
                {
                    var Ad = new AdvertisementDA().GetAdvertisementsByID(AdID);
                    return PartialView("_AddEditAdvertisement", Ad);
                }
            }
            catch (Exception ex)
            {
                return PartialView("Error", ex);
            }
        }


        public string DeleteAdvertisement(int AdID)
        {
            try
            {
                CheckSessionStatus();   //--- Check if sess["username"] exist. Else redirect to Home Page ---//

                var rowsEffected = new AdvertisementDA().DeleteAdvertisements(AdID);

                if (rowsEffected >= 1)
                    return "Success";
                else
                    return "Error";
            }
            catch (Exception)
            {
                return "Error";
            }
        }


        [HttpPost]
        public string UploadAdImageTempForPreview()
        {
            try
            {
                //--- UPLOAD IMAGES TO SHARED LOCATION ---//
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    //--- Upload File to Folder Location ---//
                    var FileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/_ImageUploads/Temp/"), FileName);
                    file.SaveAs(path);

                    return "Success";
                }
                else
                    return "NoFiles";
            }
            catch (Exception)
            {
                return "Error";
            }
        }




}
}