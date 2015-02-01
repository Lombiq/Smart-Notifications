using JetBrains.Annotations;
using Lombiq.SmartNotifications.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Localization;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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