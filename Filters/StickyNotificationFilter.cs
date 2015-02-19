using Lombiq.SmartNotifications.Models;
using Lombiq.SmartNotifications.Services;
using Orchard;
using Orchard.Mvc.Filters;
using Orchard.Settings;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.Mvc;
using Orchard.Localization;

namespace Lombiq.SmartNotifications.Filters
{
    public class StickyNotificationFilter : FilterProvider, IActionFilter
    {
        private readonly INotifier _notifier;
        private readonly INotificationManager _notificationManager;
        private readonly ISiteService _siteService;
        private readonly IHttpContextAccessor _hca;

        private const string TempDataMessages = "messages";


        public StickyNotificationFilter(
            INotifier notifier,
            INotificationManager notificationManager,
            ISiteService siteService,
            IHttpContextAccessor hca)
        {
            _notifier = notifier;
            _notificationManager = notificationManager;
            _siteService = siteService;
            _hca = hca;
        }


        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(!_siteService.GetSiteSettings().As<SmartNotificationsPart>().MakeAllNotificationsSticky) return;
            
            var tempData = filterContext.Controller.TempData;
            var sb = new StringBuilder();
            // This foreach will save the currently displayed notifications to the database. 
            foreach (var entry in _notifier.List())
            {
                if (!entry.Message.ToString().StartsWith(Constants.Sticky))
                    _notificationManager.SaveNotification(_hca.Current().Session.SessionID, entry.Message.ToString(), entry.Type);
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            // This foreach reads all notifications from the database.
            foreach (var notification in _notificationManager.GetNotifications(_hca.Current().Session.SessionID))
            {
                if(!notification.NotificationMessage.StartsWith(Constants.Sticky) && _siteService.GetSiteSettings().As<SmartNotificationsPart>().MakeAllNotificationsSticky)
                    _notifier.Add(notification.NotificationType, new LocalizedString(string.Format("{0}{1}@{2}", Constants.Sticky, notification.Id, notification.NotificationMessage)));
            }
        }
    }
}