using Orchard.Data.Conventions;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Lombiq.SmartNotifications.Models
{
    public class StickyNotificationRecord : IStickyNotification
    {
        
        public virtual int Id { get; set; }
        public virtual string SessionId { get; set; }
        public virtual NotifyType NotificationType { get; set; }
        [StringLengthMax]
        public virtual string NotificationMessage { get; set; }
    }
}