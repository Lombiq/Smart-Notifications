using Lombiq.SmartNotifications.Models;
using Orchard;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Services
{
    public interface INotificationManager : IDependency
    {
        /// <summary>
        /// This method gets the notifications for the actual user.
        /// </summary>
        /// <param name="SessionId">The session ID actual user.</param>
        /// <returns>Returns the notification messages for the actual user.</returns>
        IEnumerable<IStickyNotificationRecord> GetNotifications(string SessionId);

        /// <summary>
        /// This method saves the notifications to database.
        /// </summary>
        /// <param name="SessionId">The session ID of the actual user.</param>
        /// <param name="NotificationMessage">The notification message.</param>
        /// <param name="NotificationType">The notification type.</param>
        void SaveNotification(string SessionId, string NotificationMessage, NotifyType NotificationType);

        /// <summary>
        /// This method removes the selcted record from the table.
        /// </summary>
        /// <param name="SessionId">The session ID of the user.</param>
        /// <param name="Id">The unique id of the notification.</param>
        void DeleteNotification(string SessionId, int Id);
    }
}