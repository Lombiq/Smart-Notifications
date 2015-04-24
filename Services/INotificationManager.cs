using Lombiq.SmartNotifications.Models;
using Orchard;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Security;

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
        /// This method removes the selected record from the table.
        /// </summary>
        /// <param name="sessionId">The session ID of the user.</param>
        /// <param name="id">The unique id of the notification.</param>
        void DeleteNotification(string sessionId, int id);
    }


    public static class NotificationManagerExtensions
    {
        private const string SessionIdPrefix = "Users.";


        public static IEnumerable<IStickyNotification> GetNotificationsOfUser(this INotificationManager notificationManager, IUser user)
        {
            if (user == null) return Enumerable.Empty<IStickyNotification>();
            return notificationManager.GetNotifications(MakeId(user));
        }

        public static void SaveNotificationForUser(this INotificationManager notificationManager, IUser user, string notificationMessage, NotifyType notificationType)
        {
            notificationManager.SaveNotification(MakeId(user), notificationMessage, notificationType);
        }

        public static void DeleteNotificationOfUser(this INotificationManager notificationManager, IUser user, int id)
        {
            notificationManager.DeleteNotification(MakeId(user), id);
        }


        private static string MakeId(IUser user)
        {
            return SessionIdPrefix + user.Id;
        }
    }
}