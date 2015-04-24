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
        private readonly IWorkContextAccessor _wca;


        public StickyNotificationFilter(
            INotifier notifier,
            INotificationManager notificationManager,
            IWorkContextAccessor wca)
        {
            _notifier = notifier;
            _notificationManager = notificationManager;
            _wca = wca;
        }


        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var workContext = _wca.GetContext();
            if (!workContext.CurrentSite.As<SmartNotificationsPart>().MakeAllNotificationsSticky) return;

            // This foreach will save the currently displayed notifications to the database. 
            foreach (var entry in _notifier.List())
            {
                if (!entry.Message.Text.StartsWith(Constants.Sticky))
                {
                    if (workContext.CurrentUser == null)
                    {
                        _notificationManager.SaveNotification(workContext.HttpContext.Session.SessionID, entry.Message.Text, entry.Type); 
                    }
                    else
                    {
                        _notificationManager.SaveNotificationForUser(workContext.CurrentUser, entry.Message.Text, entry.Type);
                    }
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var workContext = _wca.GetContext();

            // Reading all notifications from the database.
            var notifications = _notificationManager
                .GetNotifications(workContext.HttpContext.Session.SessionID)
                .Union(_notificationManager.GetNotificationsOfUser(workContext.CurrentUser));

            foreach (var notification in notifications)
            {
                _notifier.Add(notification.NotificationType, new LocalizedString(string.Format("{0}{1}@{2}", Constants.Sticky, notification.Id, notification.NotificationMessage)));
            }
        }
    }
}