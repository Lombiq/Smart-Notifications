using Orchard.Mvc.Routes;
using Orchard.WebApi.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Lombiq.SmartNotifications.Routes
{
    public class HttpRoutes : IHttpRouteProvider
    {
        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] { new HttpRouteDescriptor {
                Name="StickyControllerApi",
                Priority = 5,
                RouteTemplate = "api/{controller}/{id}",
                Defaults = new {
                    area = "Lombiq.SmartNotifications",
                    id = RouteParameter.Optional
                }
            }};
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }
    }
}