using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GCETNChapter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            // Add code to fire when a web request is sent (similar to page_load event)
        }

        protected void Session_Start()
        {
            //int value = Convert.ToInt32(Session["usercount"].ToString()) + 1;
            //Session.Remove("usercount");
            //Session.Add("usercount", value);
        }

        protected void Session_End()
        {
            //if (Session["username"] == null)
            //    Response.Redirect("~/");
        }
    }
}
