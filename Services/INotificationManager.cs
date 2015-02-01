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
        /// <param name="sessionId">The session ID actual user.</param>
        /// <returns>Returns the notification messages for the actual user.</returns>
        IEnumerable<IStickyNotification> GetNotifications(string sessionId);

        /// <summary>
        /// This method saves the notifications to database.
        /// </summary>
        /// <param name="sessionId">The session ID of the actual user.</param>
        /// <param name="notificationMessage">The notification message.</param>
        /// <param name="notificationType">The notification type.</param>
        void SaveNotification(string sessionId, string notificationMessage, NotifyType notificationType);

        /// <summary>
        /// This method removes the selcted record from the table.
        /// </summary>
        /// <param name="sessionId">The session ID of the user.</param>
        /// <param name="id">The unique id of the notification.</param>
        void DeleteNotification(string sessionId, int id);
    }
}