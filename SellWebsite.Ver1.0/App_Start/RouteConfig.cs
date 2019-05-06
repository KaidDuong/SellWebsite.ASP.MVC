using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SellWebsite.Ver1._0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
             * route configure to single xem thong tin san pham chi tiet
             */

            routes.MapRoute(
                name: "Single",
                url: "{tenSp}-{id}",
                defaults: new {controller = "Product", action ="XemchiTiet",id=UrlParameter.Optional}
                );
            /*
             * route default to index
             */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
