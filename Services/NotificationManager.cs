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

        public IEnumerable<IStickyNotificationRecord> GetNotifications(string SessionId)
        {
            return _notificationRepository.Table.Where(record => record.SessionId == SessionId).OrderBy(record => record.Id);
        }

        public void SaveNotification(string SessionId, string NotificationMessage, NotifyType NotificationType)
        {   
            var notification = new StickyNotificationRecord();
            _notificationRepository.Create(notification);
            notification.SessionId = SessionId;
            notification.NotificationMessage = NotificationMessage;
            notification.NotificationType = NotificationType;
        }

        public void DeleteNotification(string SessionId, int Id)
        {
            var notification = _notificationRepository.Get(Id);
            //If the second condition wouldn't be present anybody would be able to delete notifications by knowing someone else's session ID.
            if (notification != null && notification.SessionId == SessionId)
            {
                _notificationRepository.Delete(notification);
            }
        }
    }
}