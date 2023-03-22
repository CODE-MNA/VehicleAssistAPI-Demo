using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Application.Customer.Commands
{
    public class DeleteReminderCommand : IRequest<Unit>
    {
        public int ReminderId { get; set; }

        public int CustomerId { get; set; }
    }


    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, Unit>
    {
        IBaseRepository<Reminder> _genericReminderRepository;
        IUnitOfWork _unitOfWork;

        public DeleteReminderCommandHandler(IBaseRepository<Reminder> genericReminderRepository, IUnitOfWork unitOfWork)
        {
            _genericReminderRepository = genericReminderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {

            var Reminder = _genericReminderRepository.GetById(request.ReminderId);


            if (Reminder == null)
            {
                throw new ReminderDoesntExistException("Reminder not found");

            };

            if (Reminder.CustomerId != request.CustomerId)
            {
                throw new CustomerDoesntExistException("Customer mismatch");
            };



            _genericReminderRepository.Delete(Reminder);

            _unitOfWork.CommitChanges();

            return Unit.Value;



        }
    }
}
