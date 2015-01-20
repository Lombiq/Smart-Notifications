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
    public class StickyController : ApiController
    {
        private readonly IWorkContextAccessor _wca;
        private readonly INotificationManager _notificationManager;

        public StickyController(
            INotificationManager notificationManager,
            IWorkContextAccessor wca)
        {
            _notificationManager = notificationManager;
            _wca = wca;
        }
        
        public HttpResponseMessage Delete(int id)
        {
            _notificationManager.DeleteNotification(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}