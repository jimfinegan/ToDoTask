using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToDoTasks
{
    /// <summary>
    /// Sets up the routing
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// The default route is set up.
        /// </summary>
        /// <param name="routes">The route collection</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { 
                    controller = "Home", 
                    action = "Login", 
                    id = UrlParameter.Optional 
                }
            );
        }
    }
}