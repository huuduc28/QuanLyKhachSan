using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebHotel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Product", "{type}/{meta}",
                new { Controller = "Product", action = "Index", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    {"type","phong" }
                },
            namespaces: new[] { "WebHotel.Controllers" });

            routes.MapRoute("Detail", "{type}/{meta}/{id}",
                new { Controller = "Product", action = "Detail", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    {"type","phong" }
                },
            namespaces: new[] { "WebHotel.Controllers" });

            routes.MapRoute("BookRoom", "{type}/{meta}/{id}",
               new { Controller = "Booking", action = "Detail", id = UrlParameter.Optional },
               new RouteValueDictionary
               {
                    {"type","datphong" }
               },
            namespaces: new[] { "WebHotel.Controllers" });

            routes.MapRoute("News", "{type}/{meta}/{id}",
              new { Controller = "New", action = "Detail", id = UrlParameter.Optional },
              new RouteValueDictionary
              {
                    {"type","tintuc" }
              },
            namespaces: new[] { "WebHotel.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebHotel.Controllers" }

            );
        }
    }
}
