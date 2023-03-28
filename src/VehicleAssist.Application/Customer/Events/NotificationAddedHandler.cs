using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Member;
using VehicleAssist.Domain.Notification;
using VehicleAssist.Infrastructure.NotificationService;

namespace VehicleAssist.Application.Customer.Events
{

  
    public class NotificationAddedEvent : INotification
    {
       public SendType sendType;
       public string message;
       public int memberId;
        public DateTime timeToSendNotification;
        public string memberEmail;
    }

    internal class NotificationAddedHandler : INotificationHandler<NotificationAddedEvent>
    {
        IBaseRepository<Notification> _notificationRepository;
        INotificationSchedulingService _scopedNotificationService;
        IUnitOfWork _unitOfWork;
       IMemberRepository _memberRepository;

        public NotificationAddedHandler(IBaseRepository<Notification> notificationRepository,
            INotificationSchedulingService scopedNotificationService, 
            IUnitOfWork unitOfWork, IMemberRepository memberRepository)
        {
            _notificationRepository = notificationRepository;
            _scopedNotificationService = scopedNotificationService;
            _unitOfWork = unitOfWork;
            _memberRepository = memberRepository;
        }

        public async Task Handle(NotificationAddedEvent eventData, CancellationToken cancellationToken)
        {

           Member member =  _memberRepository.GetById(eventData.memberId);
            eventData.memberEmail = member.Email;    
            
            string jobId =   _scopedNotificationService.ScheduleNotificationJob(eventData);

            
            Notification notify = new Notification()
            {
                SendType = eventData.sendType,
                Content = eventData.message,
                MemberId = eventData.memberId,
                JobID = jobId,
                TriggerTime = eventData.timeToSendNotification,
               
            };


            _notificationRepository.Add(notify);
            await _unitOfWork.CommitChangesAsync(); 
           
        }
    }
}
