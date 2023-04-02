using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Notification;

namespace VehicleAssist.Application.Customer.Queries
{
    // declare request format for notifications
    public record NotificationsForCustomerRequest : IRequest<NotificationsForCustomerResponse>
    {
        public int CustomerId { get; set; }
    }

    // declare response format for notifications
    public record NotificationsForCustomerResponse
    {
        public List<NotificationDTO>? Notifications { get; set; }
    }

    // notification query handler
    public class NotificationsForCustomerQueryHandler : IRequestHandler<NotificationsForCustomerRequest, NotificationsForCustomerResponse>
    {
        // declare notification repository
        INotificationRepository _notificationRepository;

        // dependency injection for notification repository
        public NotificationsForCustomerQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<NotificationsForCustomerResponse> Handle(NotificationsForCustomerRequest request, CancellationToken cancellationToken)
        {
            // set customerId
            int customerId = request.CustomerId;

            // get notifications
            ICollection<Notification> notifications = _notificationRepository.GetNotificationsOfCustomer(customerId);

            // delcare return value
            List<NotificationDTO> notificationDTOs = new List<NotificationDTO>();

            // set dto from notification entity
            foreach(var notification in notifications)
            {
                notificationDTOs.Add(NotificationDTO.FromEntity(notification));
            }

            // set response and return
            return new NotificationsForCustomerResponse() { Notifications = notificationDTOs };
        }
    }
}
