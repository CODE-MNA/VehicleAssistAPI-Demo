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
    public class UpdateVehicleInformationCommand : IRequest<Unit>
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }

        public string? PlateNumber { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }

        public int? Mileage { get; set; }

        public string? ImageLink { get; set; }


        public int CustomerId { get; set; }



    }

    public class UpdateVehicleInformationCommandHandler : IRequestHandler<UpdateVehicleInformationCommand,Unit>
    {

        private IBaseRepository<Vehicle> _vehicleRepository;
        private IUnitOfWork _unitOfWork;

        public UpdateVehicleInformationCommandHandler(IBaseRepository<Vehicle> vehicleRepository, IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateVehicleInformationCommand request, CancellationToken cancellationToken)
        {
         
          var vehicle =   _vehicleRepository.GetById(request.VehicleId);

            if (vehicle == null)
            {
                throw new VehicleDoesntExistException("Can't Update Vehicle");
            }

            vehicle.UpdateVehicleData(request.Name,request.PlateNumber,request.Description,request.Color,request.Mileage,request.ImageLink);

            _vehicleRepository.Update(vehicle);

            _unitOfWork.CommitChanges();



            return Unit.Value;

        }
    }
}
