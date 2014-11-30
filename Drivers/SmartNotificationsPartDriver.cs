using Lombiq.SmartNotifications.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Drivers
{
    public class SmartNotificationsPartDriver : ContentPartDriver<SmartNotificationsPart>
    {
        protected override DriverResult Editor(SmartNotificationsPart part, dynamic shapeHelper)
        {
            return Editor(part, null, shapeHelper);

        }

        protected override DriverResult Editor(SmartNotificationsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            return ContentShape("Parts_SmartNotifications_Settings_Edit",
                () =>
                {
                    if (updater != null)
                    {
                        updater.TryUpdateModel(part, Prefix, null, null);
                    }

                    return shapeHelper.EditorTemplate(
                        TemplateName: "Parts.SmartNotifications.Settings",
                        Model: part,
                        Prefix: Prefix);
                });
        }
    }
}