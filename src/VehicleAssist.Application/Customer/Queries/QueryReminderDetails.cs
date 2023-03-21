using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Application.Customer.Queries
{
    public record ReminderDetailsQuery : IRequest<ReminderDTO>
    {
        public int ReminderId { get; set; }
        public int CustomerId { get; set; }

    }



    public class ReminderDetailsQueryHandler : IRequestHandler<ReminderDetailsQuery, ReminderDTO>
    {

        IBaseRepository<Reminder> _reminderRepository;

        public ReminderDetailsQueryHandler(IBaseRepository<Reminder> reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task<ReminderDTO> Handle(ReminderDetailsQuery request, CancellationToken cancellationToken)
        {

            var reminderEntity = _reminderRepository.GetById(request.ReminderId);
            if (reminderEntity == null)
            {
                throw new ReminderDoesntExistException("Reminder with this ID doesn't exist");

            }

            if (reminderEntity.CustomerId != request.CustomerId)
            {
                throw new ReminderDoesntExistException("Reminder with this ID doesn't belong to this customer");
            }

            var dto = ReminderDTO.FromReminder(reminderEntity);

            return dto;


        }
    }
}
