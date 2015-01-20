using Lombiq.SmartNotifications.Models;
using Orchard.Data;
using Orchard.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lombiq.SmartNotifications.Services
{
    public class NotificationManager : INotificationManager
    {
        private readonly IRepository<StickyNotificationRecord> _notificationRepository;
        private readonly IHttpContextAccessor _hca;

        public NotificationManager(
            IRepository<StickyNotificationRecord> notificationRepository,
            IHttpContextAccessor hca)
        {
            _notificationRepository = notificationRepository;
            _hca = hca;
        }

        public IEnumerable<StickyNotificationRecord> GetNotifications()
        {
            return _notificationRepository.Table.Where(record => record.SessionId == _hca.Current().Session.SessionID).OrderBy(record => record.Id);
        }

        public void SaveNotification(string NotificationMessage, string NotificationType)
        {   
            var notification = new StickyNotificationRecord();
            _notificationRepository.Create(notification);
            notification.SessionId = _hca.Current().Session.SessionID;
            notification.NotificationMessage = NotificationMessage;
            notification.NotificationType = NotificationType;
        }

        public void DeleteNotification(int id)
        {
            var notification = _notificationRepository.Get(id);
            //If the second condition wouldn't be present anybody would be able to delete notifications by knowing someone else's session ID.
            if (notification != null && notification.SessionId == _hca.Current().Session.SessionID)
            {
                _notificationRepository.Delete(notification);
            }
        }
    }
}