using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Application.Customer.Commands
{
    public class UpdateReminderCommand : IRequest<Unit>
    {
        public int ReminderId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReminderDateTime { get; set; }


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

        public UpdateReminderCommandHandler(IBaseRepository<Reminder> reminderRepository, IUnitOfWork unitOfWork)
        {
            _reminderRepository = reminderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
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

            reminder.UpdateReminderData(request.Name,request.Description,request.ReminderDateTime,request.ServiceType,request.Latitude,request.Longitude,schedules);

            _reminderRepository.Update(reminder);

            _unitOfWork.CommitChanges();



            return Unit.Value;
        }
    }
}
