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

namespace Lombiq.SmartNotifications
{
    public class StickyFilter : FilterProvider, IActionFilter
    {
        private const string TempDataMessages = "messages";
        private readonly IWorkContextAccessor _wca;
        private readonly INotifier _notifier;
        private readonly INotificationManager _notificationManager;
        private readonly IOrchardServices _os;

        public StickyFilter(
            IWorkContextAccessor wca,
            INotifier notifier,
            INotificationManager notificationManager,
            IOrchardServices os)
        {
            _wca = wca;
            _notifier = notifier;
            _notificationManager = notificationManager;
            _os = os;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if ((_os.WorkContext.CurrentSite.As<SmartNotificationsPart>()).MakeAllNotificationsSticky)
            {
                var tempData = filterContext.Controller.TempData;
                var sb = new StringBuilder();
                //This foreach will save the currently displayed notifications to the database. 
                foreach (var entry in _notifier.List())
                {
                    _notificationManager.SaveNotification(entry.Message.ToString(), Convert.ToString(entry.Type));
                }
                //This foreach reads all notifications from the database.
                foreach (var row in _notificationManager.GetNotifications())
                {
                    sb.Append(Convert.ToString(row.NotificationType)).Append(':').AppendLine(string.Format("{0}|{1}", row.NotificationMessage, row.Id)).AppendLine("-");
                }
                tempData[TempDataMessages] = sb.ToString();
            } 
        }
        public void OnActionExecuting(ActionExecutingContext filterContext) {}
    }
}