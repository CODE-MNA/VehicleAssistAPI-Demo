using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Member;
using VehicleAssist.Domain.Notification;

namespace VehicleAssist.Application.Customer
{
    public class NotificationDTO
    {
        public int NotificationId { get; set; }

        public SendType SendType { get; set; }

        public string Content { get; set; }

        public string TriggerTime { get; set; }

        public static NotificationDTO FromEntity(Notification notification)
        {
            return new NotificationDTO()
            {
                NotificationId = notification.NotificationId,
                SendType = notification.SendType,
                Content = notification.Content,
                // UTC time format e.g 2023-04-02T00:34:03Z
                TriggerTime = notification.TriggerTime.ToUniversalTime().ToString("u").Replace(" ", "T")
            };
        }
    }
}
