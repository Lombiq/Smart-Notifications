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
    [UsedImplicitly]
    public class SmartNotificationsPartHandler : ContentHandler
    {
        public SmartNotificationsPartHandler(IRepository<SmartNofiticationsPartRecord> repository) 
        {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<SmartNotificationsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<SmartNotificationsPart>("SmartNotificationsSettings", "Parts/SmartNotifications.Settings","Modules"));
        }

        public Localizer T { get; set; }

        protected override void GetItemMetadata(GetContentItemMetadataContext context)
        {
            
            
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("Module")));
        }
    }
}