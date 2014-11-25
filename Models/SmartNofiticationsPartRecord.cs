using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Models
{
    public class SmartNofiticationsPartRecord : ContentPartRecord
    {
        public virtual bool isFading { get; set; }
        public virtual bool isClosable {get; set; }
    }
}