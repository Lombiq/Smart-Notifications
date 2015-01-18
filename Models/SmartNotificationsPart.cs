using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Models
{
    public class SmartNotificationsPart : ContentPart
    {
        public bool IsFading 
        {
            get { return this.Retrieve(x => x.IsFading); }
            set { this.Store(x => x.IsFading, value); }
        }

        public bool IsClosable
        {
            get { return this.Retrieve(x => x.IsClosable); }
            set { this.Store(x=>x.IsClosable, value ); }
        }

        public bool IsSticky
        {
            get { return this.Retrieve(x => x.IsSticky); }
            set { this.Store(x => x.IsSticky, value); }
        }
    }
}