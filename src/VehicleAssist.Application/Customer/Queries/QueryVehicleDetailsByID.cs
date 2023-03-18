using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.Application.Customer.Queries
{
    public record VehicleDetailsQuery : IRequest<VehicleDTO>
    {
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }

    }

    public class VehicleDetailsQueryHandler : IRequestHandler<VehicleDetailsQuery, VehicleDTO>
    {

        IBaseRepository<Vehicle> _vehicleRepository;

        public VehicleDetailsQueryHandler(IBaseRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDTO> Handle(VehicleDetailsQuery request, CancellationToken cancellationToken)
        {
           
            var vehicleEntity = _vehicleRepository.GetById(request.VehicleId);
            if(vehicleEntity == null)
            {
                throw new VehicleDoesntExistException("Vehicle with this ID doesn't exist");

            }

            if (vehicleEntity.CustomerId  != request.CustomerId)
            {
                throw new VehicleDoesntExistException("Vehicle with this ID doesn't belong to this customer");
            }

            var dto = VehicleDTO.FromVehicle(vehicleEntity);

            return dto;


        }
    }



}
