using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer.Events;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Application.Customer.Commands
{
    public class UpdateReminderCommand : IRequest<Unit>
    {
        public int ReminderId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset ReminderDateTime { get; set; }


        public string ServiceType { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int CustomerId { get; set; }

        public List<ReminderScheduleDTO> ReminderSchedules { get; set; }


    }

    public class UpdateReminderCommandHandler : IRequestHandler<UpdateReminderCommand, Unit>
    {
        IBaseRepository<Reminder> _reminderRepository;
        IUnitOfWork _unitOfWork;
        IPublisher _publisher;
     INotificationRepository _notificationRepository;

        public UpdateReminderCommandHandler(IBaseRepository<Reminder> reminderRepository, IUnitOfWork unitOfWork,
            IPublisher publisher, INotificationRepository notificationRepository)
        {
            _reminderRepository = reminderRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
            _notificationRepository = notificationRepository;
        }

        public async Task<Unit> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
            DateTime utcTime = request.ReminderDateTime.UtcDateTime;

            var reminder = _reminderRepository.GetById(request.ReminderId);

            if (reminder == null)
            {
                throw new ReminderDoesntExistException("Can't Update reminder");
            }

           List<ReminderAlarmSchedule> schedules = new List<ReminderAlarmSchedule>();

            foreach (var item in request.ReminderSchedules)
            {
                var time = ReminderAlarmSchedule.CreateReminderSchedule(item.TimeBefore, item.ScheduleType);

                schedules.Add(time);
            }

            reminder.UpdateReminderData(request.Name,request.Description,utcTime,request.ServiceType,request.Latitude,request.Longitude,schedules);

            _reminderRepository.Update(reminder);

            _unitOfWork.CommitChanges();

            //Delete -----
            List<string?>? jobs = _notificationRepository.GetJobIdsUsingReferenceId(request.ReminderId);

            if (jobs == null)
            {
                return Unit.Value;

            }


            //Publish event

            foreach (var item in jobs)
            {
                if (string.IsNullOrWhiteSpace(item)) continue;

                var notify = new NotificationDeletedEvent()
                {
                    jobId = item
                };

                await _publisher.Publish(notify);
            }

            //ADd ----

            List<NotificationAddedEvent> events = new List<NotificationAddedEvent>();

            events.Add(new NotificationAddedEvent()
            {
                referenceId = reminder.ReminderId,
                sendType = Domain.Notification.SendType.FinalReminder,
                timeToSendNotification = reminder.ReminderDateTime,
                memberId = request.CustomerId,
                message = $"Hi, You have a reminder!\n {reminder.Name} : {reminder.Description}"

            });

            foreach (var item in reminder.GetExtraScheduleDateTimes())
            {


                events.Add(new NotificationAddedEvent()
                {
                    referenceId = reminder.ReminderId,
                    sendType = Domain.Notification.SendType.ReminderPreparation,
                    timeToSendNotification = item,
                    memberId = request.CustomerId,
                    message = $"Hi, we are reminding you that you have to do : {reminder.Name} on {request.ReminderDateTime.LocalDateTime.ToString()}"
                });
            }


            foreach (var addedEvent in events)
            {

             

               await _publisher.Publish(addedEvent, default);

            }


            



          


            return Unit.Value;
        }
    }
}
