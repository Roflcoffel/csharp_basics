﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCBasics.Assignments
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TempratureCheck",
                url: "FeverCheck",
                defaults: new {controller = "Temp", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GuessingGame",
                url: "GuessingGame",
                defaults: new { controller = "Game", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
