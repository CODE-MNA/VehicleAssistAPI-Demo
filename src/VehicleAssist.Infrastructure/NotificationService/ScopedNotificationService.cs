using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;

namespace VehicleAssist.Infrastructure.NotificationService
{
    internal class ScopedNotificationService : IScopedNotificationService
    {

        Action<int,string> FirstTestAction;

        public ScopedNotificationService()
        {
            FirstTestAction = (int id, string action) => { Console.WriteLine("Executing Notification- " + id + " : " + action); };
        }

        public Task CheckForNotificationAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        public void ScheduleNotificationJob(int notificationId, string content, DateTime timeToExecute, CancellationToken stoppingToken)
        {
            string jobId = BackgroundJob.Schedule(() => ExecuteNotifications(notificationId,content) , timeToExecute);
        }


        public async Task ExecuteNotifications(int notificationId, string content)
        {
            await Task.Delay(1000);
            Console.WriteLine("Sheeesh" + " " + " id : " + notificationId + " , content : " + content);
        }


    }
}
