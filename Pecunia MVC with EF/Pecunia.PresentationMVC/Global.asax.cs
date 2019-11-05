using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pecunia.PresentationMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            //user defined bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);
             
            //web api routing
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
