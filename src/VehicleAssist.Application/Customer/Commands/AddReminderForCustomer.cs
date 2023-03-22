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
   
        public class AddReminderForCustomerCommand : IRequest<Unit>
        {

   

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReminderDateTime { get; set; }


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

            public AddReminderForCustomerCommandHandler(ICustomerRepository vehicleOwnerRepository, IUnitOfWork unitOfWork)
            {
                _vehicleOwnerRepository = vehicleOwnerRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(AddReminderForCustomerCommand request, CancellationToken cancellationToken)
            {

            //Can refactor later to use the domain function
            Reminder reminder = new Reminder(request.Name, request.Description, request.ReminderDateTime, request.ServiceType, request.Latitude, request.Longitude);

            foreach (var item in request.ReminderSchedules)
            {
                ReminderAlarmSchedule newSchedule = ReminderAlarmSchedule.CreateReminderSchedule(item.TimePrior, item.ScheduleType);
                reminder.AddSchedule(newSchedule);


            }
            _vehicleOwnerRepository.AddReminderToCustomer(request.CustomerId, reminder);

                 _unitOfWork.CommitChanges();


                return Unit.Value;
            }
        }
    
}
