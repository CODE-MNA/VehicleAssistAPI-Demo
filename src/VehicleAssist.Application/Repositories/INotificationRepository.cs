using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Notification;

namespace VehicleAssist.Application.Repositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        public Notification? GetNotificationUsingJobId(string jobId);    
        public List<string?>? GetJobIdsUsingReferenceId(int referenceId);
        public ICollection<Notification> GetNotificationsOfCustomer(int customerMemberId);
    }
}
