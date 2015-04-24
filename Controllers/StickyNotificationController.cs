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
    public class StickyNotificationController : ApiController
    {
        private readonly INotificationManager _notificationManager;
        private readonly IWorkContextAccessor _wca;


        public StickyNotificationController(INotificationManager notificationManager, IWorkContextAccessor wca)
        {
            _notificationManager = notificationManager;
            _wca = wca;
        }


        public HttpResponseMessage Delete(int id)
        {
            var workContext = _wca.GetContext();

            _notificationManager.DeleteNotification(workContext.HttpContext.Session.SessionID, id);

            if (workContext.CurrentUser != null)
            {
                _notificationManager.DeleteNotificationOfUser(workContext.CurrentUser, id);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}