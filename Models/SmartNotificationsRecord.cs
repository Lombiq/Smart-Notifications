using Orchard.Data.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Models
{
    public class SmartNotificationsRecord
    {
        public virtual int Id { get; set; }//unique identifier of the notification message
        public virtual string UserId { get; set; }//we must save the user id, because the notification messages are connected to user
        public virtual string NotificationMessage { get; set; }//the notification message
    }
}