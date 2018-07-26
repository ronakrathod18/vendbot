using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VendBot
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "GetItem",
                "getItem/{type}/{id}",
                new
                {
                    controller = "Home",
                    action = "GetItem",
                    type = UrlParameter.Optional,
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
                "StockItem",
                "stockItem/{type}/{id}/{count}",
                new
                {
                    controller = "Home",
                    action = "StockItem",
                    type = UrlParameter.Optional,
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
