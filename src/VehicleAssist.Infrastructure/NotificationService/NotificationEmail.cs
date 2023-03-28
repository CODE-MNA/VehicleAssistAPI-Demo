using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Notification;
using VehicleAssist.Infrastructure.Email;

namespace VehicleAssist.Infrastructure.NotificationService
{
    internal class NotificationEmail : INotificationEmail
    {
        IMailService _mailService;
        MailSettings _mailSettings;

        public NotificationEmail(IMailService mailService, IOptions<MailSettings> mailSettings)
        {
            _mailService = mailService;
            _mailSettings = mailSettings.Value;
        }

        public Task SendNotificationEmail(string content, SendType sendType, string email)
        {
            MailRequest mailRequest = new MailRequest();

            switch (sendType)
            {
                case SendType.ReminderPreparation:
                    mailRequest.Subject = "Upcoming reminder for VehicleAssist.";


                    break;
                case SendType.FinalReminder:
                    mailRequest.Subject = "You have a message from Vehicle Assist!";

                    break;
                default:
                    break;
            }

            try
            {


                mailRequest.ToEmail = email;

                mailRequest.Arguments = content;

                mailRequest.BodyRazorTemplate = @"<h1>Vehicle Assist </h1><br>, @Model";

                return _mailService.SendMailAsync(mailRequest);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
