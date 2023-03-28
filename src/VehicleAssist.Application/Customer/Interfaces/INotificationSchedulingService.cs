using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer.Events;

namespace VehicleAssist.Infrastructure.NotificationService
{
    public interface INotificationSchedulingService
    {
        public string ScheduleNotificationJob(NotificationAddedEvent eventData);
        public bool DeleteJob(string jobId);
    }
}
