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
    public class NotificationUpdatedEvent : INotification
    {
       public int referenceId;
        public SendType sendType;
        public string message;
        public int memberId;
        public DateTime timeToSendNotification;
    

    
    }

    public class NotificationUpdateHandler : INotificationHandler<NotificationUpdatedEvent>
    {
        INotificationSchedulingService _scopedNotificationService;
        INotificationRepository _notificationRepository;
        IUnitOfWork _unitOfWork;
        IMemberRepository _memberRepository;

        public NotificationUpdateHandler(INotificationSchedulingService scopedNotificationService, 
            INotificationRepository notificationRepository, 
            IUnitOfWork unitOfWork, IMemberRepository memberRepository)
        {
            _scopedNotificationService = scopedNotificationService;
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
            _memberRepository = memberRepository;
        }

        public async Task Handle(NotificationUpdatedEvent eventData, CancellationToken cancellationToken)
        {


          Notification updating = _notificationRepository.GetList(x => x.ReferenceId == eventData.referenceId).ToList().First();

            string memberEmail = _memberRepository.GetById(eventData.memberId)?.Email;
           
                updating.Content = eventData.message;

            _scopedNotificationService.DeleteJob(updating.JobID);


          


            NotificationAddedEvent notificationAddedEvent = new NotificationAddedEvent()
            {
                referenceId = eventData.referenceId,
                sendType = eventData.sendType,
                message = updating.Content,
                memberId = eventData.memberId,
                timeToSendNotification = eventData.timeToSendNotification,
                memberEmail = memberEmail,

            };

            string newId = _scopedNotificationService.ScheduleNotificationJob(notificationAddedEvent);

            updating.JobID = newId;


            _notificationRepository.Update(updating);

            await _unitOfWork.CommitChangesAsync();


        }
    }
}
