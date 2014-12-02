using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Models
{
    public class SmartNotificationsPart : ContentPart
    {
        public bool isFading 
        {
            get { return this.Retrieve(x => x.isFading); }
            set { this.Store(x => x.isFading, value); }
        }

        public bool isClosable
        {
            get { return this.Retrieve(x => x.isClosable); }
            set { this.Store(x=>x.isClosable, value ); }
        }
    }
}