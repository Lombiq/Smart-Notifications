using Lombiq.SmartNotifications.Services;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lombiq.SmartNotifications.Controllers
{
    public class StickyNotificationController : ApiController
    {
        private readonly INotificationManager _notificationManager;

        public StickyNotificationController(INotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }
        
        public HttpResponseMessage Delete(int id)
        {
            _notificationManager.DeleteNotification(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}