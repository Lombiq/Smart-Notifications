﻿using Lombiq.SmartNotifications.Models;
using Orchard;
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
        /// <returns>Returns the notification messages for the actual user.</returns>
        IEnumerable<StickyRecord> GetNotifications();

        /// <summary>
        /// This method saves the notifications to db.
        /// </summary>
        /// <param name="NotificationMessage"></param>
        /// <param name="NotificationType"></param>
        void SaveNotification(string NotificationMessage, string NotificationType);

        /// <summary>
        /// This method removes the selcted record from the table.
        /// </summary>
        /// <param name="Id"></param>
        void DeleteNotification(int Id);
    }
}