using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Infrastructure.NotificationService
{
    public interface IScopedNotificationService
    {
        public  Task CheckForNotificationAsync(CancellationToken stoppingToken);

        public void ScheduleNotificationJob(int notificationId , string content, DateTime timeToExecute, CancellationToken stoppingToken);

    }
}
