using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ns.Utility.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "KendoApi",
                routeTemplate: "api/{controller}/{take}/{skip}/{page}/{pageSize}",
                defaults: new { take = RouteParameter.Optional, skip = RouteParameter.Optional, page = RouteParameter.Optional, pageSize = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
