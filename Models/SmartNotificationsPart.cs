using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Models
{
    public class SmartNotificationsPart : ContentPart
    {
        public bool MakeAllNotificationsFading 
        {
            get { return this.Retrieve(x => x.MakeAllNotificationsFading); }
            set { this.Store(x => x.MakeAllNotificationsFading, value); }
        }

        public int FadingStartTimeMilliseconds
        {
            get { return this.Retrieve(x => x.FadingStartTimeMilliseconds, 5000); }
            set { this.Store(x => x.FadingStartTimeMilliseconds, value); }
        }

        public bool MakeAllNotificationsClosable
        {
            get { return this.Retrieve(x => x.MakeAllNotificationsClosable); }
            set { this.Store(x=>x.MakeAllNotificationsClosable, value ); }
        }

        public bool MakeAllNotificationsSticky
        {
            get { return this.Retrieve(x => x.MakeAllNotificationsSticky); }
            set { this.Store(x => x.MakeAllNotificationsSticky, value); }
        }
    }
}