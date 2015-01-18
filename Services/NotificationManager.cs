using Lombiq.SmartNotifications.Models;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Services
{
    public class NotificationManager : INotificationManager
    {
        private readonly IRepository<SmartNotificationsRecord> _notificationRepository;

        public NotificationManager(IRepository<SmartNotificationsRecord> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IEnumerable<SmartNotificationsRecord> GetNotifications(string UserId)
        {
            return _notificationRepository.Table.Where(record => record.UserId == UserId);
        }

        public void SaveNotification(string UserId, string NotificationMessage)
        {
            var exists = _notificationRepository.Table.Where(record => record.UserId == UserId && record.NotificationMessage==NotificationMessage).FirstOrDefault();
            if (exists == null)
            {
                var notification = new SmartNotificationsRecord();
                _notificationRepository.Create(notification);
                notification.UserId = UserId;
                notification.NotificationMessage = NotificationMessage;
            }
        }

        public void DeleteNotification(int id, string UserId)
        {
            var notification = _notificationRepository.Get(id);
            //the second parameter is needed, because if there was not present anybody was able to delete notifications by ID
            if (notification != null && notification.UserId == UserId)
            {
                _notificationRepository.Delete(notification);
            }
        }
    }
}