using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ToDoTasks
{
    public static class WebApiConfig
    {
        /// <summary>
        /// Sets up the default route
        /// </summary>
        /// <param name="config">The configured route.</param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
