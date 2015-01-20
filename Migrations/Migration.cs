using Orchard.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.SmartNotifications.Models;

namespace Lombiq.SmartNotifications.Migrations
{
    public class Migration : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(StickyRecord).Name, table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("SessionId")
                .Column<string>("NotificationType")
                .Column<string>("NotificationMessage")
                ).AlterTable(typeof(StickyRecord).Name, table => table
                .CreateIndex("SmartNotification", new string[] {"SessionId"})
                );

            return 1;
        }
    }
}