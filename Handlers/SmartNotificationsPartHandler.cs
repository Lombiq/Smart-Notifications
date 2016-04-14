using Lombiq.SmartNotifications.Models;
using Orchard.ContentManagement.Handlers;

namespace Lombiq.SmartNotifications.Handlers
{
    public class SmartNotificationsPartHandler : ContentHandler
    {
        public SmartNotificationsPartHandler()
        {
            Filters.Add(new ActivatingFilter<SmartNotificationsPart>("Site"));
        }
    }
}