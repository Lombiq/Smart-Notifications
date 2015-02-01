using Lombiq.SmartNotifications.Models;
using Orchard.Data;
using Orchard.Mvc;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Services
{
    public class NotificationManager : INotificationManager
    {
        private readonly IRepository<StickyNotificationRecord> _notificationRepository;


        public NotificationManager(IRepository<StickyNotificationRecord> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IEnumerable<IStickyNotification> GetNotifications(string sessionId)
        {
            return _notificationRepository.Table.Where(record => record.SessionId == sessionId).OrderBy(record => record.Id);
        }

        public void SaveNotification(string sessionId, string notificationMessage, NotifyType notificationType)
        {   
            var notification = new StickyNotificationRecord();
            _notificationRepository.Create(notification);
            notification.SessionId = sessionId;
            notification.NotificationMessage = notificationMessage;
            notification.NotificationType = notificationType;
        }

        public void DeleteNotification(string sessionId, int id)
        {
            var notification = _notificationRepository.Get(id);
            // If the second condition wouldn't be present anybody would be able to delete notifications by knowing the id of someone else's notification.
            if (notification != null && notification.SessionId == sessionId)
            {
                _notificationRepository.Delete(notification);
            }
        }
    }
}