using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer.Events;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Reminders;
using VehicleAssist.Infrastructure.NotificationService;

namespace VehicleAssist.Application.Customer.Commands
{
   
        public class AddReminderForCustomerCommand : IRequest<Unit>
        {

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset ReminderDateTime { get; set; }
      
        public string ServiceType { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int CustomerId { get; set; }

        public List<ReminderScheduleDTO> ReminderSchedules { get; set; }


    }

    internal class AddReminderForCustomerCommandHandler : IRequestHandler<AddReminderForCustomerCommand, Unit>
        {
            ICustomerRepository _vehicleOwnerRepository;
            IUnitOfWork _unitOfWork;
            IPublisher _publisher;

        public AddReminderForCustomerCommandHandler(ICustomerRepository vehicleOwnerRepository, IUnitOfWork unitOfWork, IPublisher publisher)
        {
            _vehicleOwnerRepository = vehicleOwnerRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }

        public async Task<Unit> Handle(AddReminderForCustomerCommand request, CancellationToken cancellationToken)
            {

  
           DateTime time =  request.ReminderDateTime.UtcDateTime;

            //Can refactor later to use the domain function
            Reminder reminder = new Reminder(request.Name, request.Description,time, request.ServiceType, request.Latitude, request.Longitude);


            if(request.ReminderSchedules != null && request.ReminderSchedules.Count > 0)
            {
                foreach (var item in request.ReminderSchedules)
                {
                    ReminderAlarmSchedule newSchedule = ReminderAlarmSchedule.CreateReminderSchedule(item.TimeBefore, item.ScheduleType);
                    reminder.AddSchedule(newSchedule);
 

                }

            }
            _vehicleOwnerRepository.AddReminderToCustomer(request.CustomerId, reminder);

                 _unitOfWork.CommitChanges();

            // Prepare Notification Publishing

            List<NotificationAddedEvent> events = new List<NotificationAddedEvent>();

            DateTime localTime = request.ReminderDateTime.LocalDateTime;

            var times = reminder.GetExtraScheduleDateTimes();
            if(times != null && times.Count > 0)
            {

                foreach (var item in times)
                {
                    events.Add(new NotificationAddedEvent()
                    {
                        referenceId = reminder.ReminderId,
                        sendType = Domain.Notification.SendType.ReminderPreparation,
                        timeToSendNotification = item,
                        memberId = request.CustomerId,
                        message = $"Hi, we are reminding you that you have to do : {reminder.Name} on {localTime}"
                    });
                }
            }

            events.Add(new NotificationAddedEvent()
            {
                referenceId= reminder.ReminderId,
                sendType = Domain.Notification.SendType.FinalReminder,
                timeToSendNotification = reminder.ReminderDateTime,
                memberId = request.CustomerId,
                message = $"Hi, You have a reminder!\n {reminder.Name} : {reminder.Description}"
            });



            foreach (var item in events)
            {
             
                  await  _publisher.Publish(item, CancellationToken.None);

                
            }

                return Unit.Value;
            }
        }
    
}
