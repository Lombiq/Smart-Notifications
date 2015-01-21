using Orchard;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Models
{
    public interface IStickyNotificationRecord
    {
        /// <summary>
        /// The unique identifier of the notification message.
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// We are saving the session id, because the notification messages are connected to session.
        /// </summary>
        string SessionId { get; set; }
        /// <summary>
        /// The type of the notification.
        /// </summary>
        NotifyType NotificationType { get; set; }
        /// <summary>
        /// The notification message.
        /// </summary>
        string NotificationMessage { get; set; }
    }
}