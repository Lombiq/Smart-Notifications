using Lombiq.SmartNotifications.Services;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lombiq.SmartNotifications.Controllers
{
    public class SmartNotificationsController : Controller
    {
        private INotificationManager _notificationManager;
        private IWorkContextAccessor _wca;
     
        public SmartNotificationsController(INotificationManager notificationManager, IWorkContextAccessor wca)
        {
            _notificationManager = notificationManager;
            _wca = wca;
        }

        public string SaveNotification()//string NotificationMessage
        {
            string NotificationMessage = Request.QueryString["NotificationMessage"];
            var UserID = _wca.GetContext().CurrentUser.Id;
            _notificationManager.SaveNotification(UserID.ToString(), NotificationMessage);
            return "OK";
        }

        public string RemoveNotification()
        {
            string notificationID = Request.QueryString["NotificationID"];
            int id = int.Parse(notificationID);
            _notificationManager.DeleteNotification(id, _wca.GetContext().CurrentUser.Id.ToString());
            return notificationID;
        }

        public JsonResult GetNotifications()
        {
            List<object> json = new List<object>();
            foreach (var row in _notificationManager.GetNotifications(_wca.GetContext().CurrentUser.Id.ToString()))
            {
                json.Add(new { row.Id, row.NotificationMessage });//only return insensitive data
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}