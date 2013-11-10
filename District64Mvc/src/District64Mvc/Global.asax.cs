using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace District64Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Archive", // Route name
                "Archive", // URL with parameters
                new { controller = "Archive", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Search", // Route name
                "Archive/Search", // URL with parameters
                new { controller = "Archive", action = "Search", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
               "List", // Route name
               "Archive/List", // URL with parameters
               new { controller = "Archive", action = "List", id = UrlParameter.Optional } // Parameter defaults
           );

            routes.MapRoute(
              "PDFView", // Route name
              "Archive/PDFView", // URL with parameters
              new { controller = "Archive", action = "PDFView", id = "archiveId" } // Parameter defaults
            );

            routes.MapRoute(
             "PDFEmbededView", // Route name
             "Archive/PDFEmbededView", // URL with parameters
             new { controller = "Archive", action = "PDFEmbededView", id = "archiveId" } // Parameter defaults
           );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}