using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace News.Services
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Help Area",
                string.Empty,
                new { controller = "Help", action = "Index" }
                ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
        }
    }
}
