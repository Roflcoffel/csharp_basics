using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Album",
                url: "Album/{id}",
                defaults: new { controller = "Store", action = "Detail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Genre",
                url: "{name}",
                defaults: new { controller = "Store", action = "Browse", name = "Deathcore", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
