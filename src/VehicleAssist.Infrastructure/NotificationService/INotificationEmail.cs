using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Notification;

namespace VehicleAssist.Infrastructure.NotificationService
{
    internal interface INotificationEmail
    {
        public Task SendNotificationEmail(string content,SendType sendType,string toEmail);
    }
}
