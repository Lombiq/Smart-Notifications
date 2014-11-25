using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Models
{
    public class SmartNotificationsPart : ContentPart<SmartNofiticationsPartRecord>
    {
        public bool isFading 
        {
            get { return Record.isFading; }
            set { Record.isFading = value; }
        }


        public bool isClosable
        {
            get { return Record.isClosable; }
            set { Record.isClosable = value; }
        }
    }
}