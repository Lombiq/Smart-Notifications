using Lombiq.SmartNotifications.Services;
using Orchard;
using Orchard.Mvc;
using Orchard.WebApi.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Orchard.Mvc.Routes;

namespace Lombiq.SmartNotifications.Controllers
{
    public class StickyNotificationController : ApiController, IHttpRouteProvider
    {
        private readonly INotificationManager _notificationManager;
        private readonly IHttpContextAccessor _hca;


        public StickyNotificationController(INotificationManager notificationManager,IHttpContextAccessor hca)
        {
            _notificationManager = notificationManager;
            _hca = hca;
        }
        

        public HttpResponseMessage Delete(int id)
        {
            _notificationManager.DeleteNotification(_hca.Current().Session.SessionID, id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] { new HttpRouteDescriptor {
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