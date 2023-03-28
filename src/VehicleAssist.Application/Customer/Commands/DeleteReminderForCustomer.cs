using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer.Events;
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
        INotificationRepository _notificationRepository;
        IPublisher _publisher;

        public DeleteReminderCommandHandler(IBaseRepository<Reminder> genericReminderRepository, 
            IUnitOfWork unitOfWork, 
            INotificationRepository notificationRepository, IPublisher publisher)
        {
            _genericReminderRepository = genericReminderRepository;
            _unitOfWork = unitOfWork;
            _notificationRepository = notificationRepository;
            _publisher = publisher;
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

            //Get the jobs
          List<string?>? jobs =  _notificationRepository.GetJobIdsUsingReferenceId(request.ReminderId);

            if(jobs == null)
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

                await  _publisher.Publish(notify);
            }


            return Unit.Value;


        }
    }
}
