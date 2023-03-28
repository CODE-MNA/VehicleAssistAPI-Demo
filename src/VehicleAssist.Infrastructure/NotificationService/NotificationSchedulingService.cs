using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using VehicleAssist.Application.Customer.Events;
using VehicleAssist.Domain.Notification;

namespace VehicleAssist.Infrastructure.NotificationService
{
    internal class NotificationSchedulingService : INotificationSchedulingService
    {

        INotificationEmail _emailService;

        public NotificationSchedulingService(INotificationEmail emailService)
        {
            _emailService = emailService;
        }

 
        public string ScheduleNotificationJob(NotificationAddedEvent eventData)
        {
            string jobId = BackgroundJob.Schedule(() => ExecuteNotifications(eventData.memberEmail,
                eventData.memberId,eventData.message,eventData.sendType) , eventData.timeToSendNotification);

            return jobId;
        }

        public bool DeleteJob(string jobId)
        {
           return BackgroundJob.Delete(jobId);
        }


        public async Task ExecuteNotifications(string email,int memberId, string content,SendType sendType)
        {
            Console.WriteLine($"Fired {sendType.ToString()} event to {email} - {content}");

            //Send Email
            await _emailService.SendNotificationEmail(content,sendType, email);
        }


    }
}
