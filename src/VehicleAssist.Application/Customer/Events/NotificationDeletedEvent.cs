using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Notification;
using VehicleAssist.Infrastructure.NotificationService;

namespace VehicleAssist.Application.Customer.Events
{
    public class NotificationDeletedEvent : INotification
    {
      public  string jobId;

    }
     

internal class NotificationDeletedHandler : INotificationHandler<NotificationDeletedEvent>
{
    INotificationRepository _notificationRepository;
    INotificationSchedulingService _scopedNotificationService;
    IUnitOfWork _unitOfWork;
    IMemberRepository _memberRepository;

    public NotificationDeletedHandler(INotificationRepository notificationRepository,
        INotificationSchedulingService scopedNotificationService,
        IUnitOfWork unitOfWork, IMemberRepository memberRepository)
    {
        _notificationRepository = notificationRepository;
        _scopedNotificationService = scopedNotificationService;
        _unitOfWork = unitOfWork;
        _memberRepository = memberRepository;
    }

    public async Task Handle(NotificationDeletedEvent eventData, CancellationToken cancellationToken)
    {

  
        bool deleted = _scopedNotificationService.DeleteJob(eventData.jobId);


            if (!deleted)
            {
                return;
            }
          

    


        var notification = _notificationRepository.GetNotificationUsingJobId(eventData.jobId);

            if(notification == null)
            {
                return;
            }
        
        _notificationRepository.Delete(notification);
        await _unitOfWork.CommitChangesAsync();

    }

      

}
}
