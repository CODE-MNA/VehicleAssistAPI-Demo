using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Notification;
using VehicleAssist.Infrastructure.Data;

namespace VehicleAssist.Infrastructure.NotificationService
{
    public class NotificationRepository : EFRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(VehicleAssistDBContext dbContext) : base(dbContext)
        {
        }

        public List<string?>? GetJobIdsUsingReferenceId(int referenceId)
        {

           return _dbContext.Notifications.Where(n => n.ReferenceId == referenceId).Select(c => c.JobID).Where(s => !string.IsNullOrEmpty(s)).ToList(); 
        }

        public ICollection<Notification> GetNotificationsOfCustomer(int customerMemberId)
        {
            // get latest 15 notification
            return _dbContext.Notifications.Where(n => n.MemberId == customerMemberId && n.TriggerTime <= DateTime.UtcNow).OrderByDescending(n => n.TriggerTime).Take(15).ToList().AsReadOnly();
        }

        public Notification? GetNotificationUsingJobId(string jobId)
        {
           return _dbContext.Notifications.FirstOrDefault(x => x.JobID == jobId);
        }
    }
}
