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
        /// Gets notifications for a given session ID.
        /// </summary>
        /// <param name="sessionId">The session ID.</param>
        /// <returns>Returns the notification messages for the actual user.</returns>
        IEnumerable<IStickyNotification> GetNotifications(string sessionId);

        /// <summary>
        /// Saves notifications to the database. Note that depending on how early in the request you do this save
        /// won't necessarily cause the notification to be displayed on the next load. If you want that use the
        /// <see cref="Orchard.UI.Notify.INotifier.Sticky()"/> extension method.
        /// </summary>
        /// <param name="sessionId">The session ID.</param>
        /// <param name="notificationMessage">The notification message.</param>
        /// <param name="notificationType">The notification type.</param>
        void SaveNotification(string sessionId, string notificationMessage, NotifyType notificationType);

        /// <summary>
        /// This method removes the selected record from the table.
        /// </summary>
        /// <param name="sessionId">The session ID.</param>
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