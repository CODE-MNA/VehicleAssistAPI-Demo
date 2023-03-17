using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.Application.Customer.Commands
{
    public class DeleteVehicleCommand : IRequest<Unit>
    {
        public int VehicleId { get; set; }

        public int CustomerId { get; set; }
    }


    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Unit>
    {
        IBaseRepository<Vehicle> _genericVehicleRepository;
        IUnitOfWork _unitOfWork;

        public DeleteVehicleCommandHandler(IBaseRepository<Vehicle> genericVehicleRepository, IUnitOfWork unitOfWork)
        {
            _genericVehicleRepository = genericVehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {

            var vehicle = _genericVehicleRepository.GetById(request.VehicleId);


            if(vehicle == null)
            {
                throw new VehicleDoesntExistException("Vehicle not found");

            };

            if(vehicle.CustomerId != request.CustomerId)
            {
                throw new CustomerDoesntExistException("Customer mismatch");
            };



            _genericVehicleRepository.Delete(vehicle);

            _unitOfWork.CommitChanges();

            return Unit.Value;
            


        }
    }
}
