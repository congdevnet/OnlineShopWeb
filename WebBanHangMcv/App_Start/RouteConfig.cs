using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHangMcv
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Sanphamchitiet",
                url: "{MetaTitle}/sp/{id}",
                defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Danhmuc",
                url: "{Link}_dm_{id}",
                defaults: new { controller = "Danhmuc", action = "GetDanhmuc", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
