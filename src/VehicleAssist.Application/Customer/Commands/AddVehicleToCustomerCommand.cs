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
    public class AddVehicleToCustomerCommand : IRequest<Unit>
    {
     
        public string Name { get;  set; }

        public string? PlateNumber { get;  set; }

        public string? Description { get;  set; }

        public string? Color { get;  set; }

        public int? Mileage { get;  set; }

        public string? ImageData { get;  set; }


        public int CustomerId { get; set; }



    }

    internal class ActivateCustomerHandler : IRequestHandler<AddVehicleToCustomerCommand, Unit>
    {
        ICustomerRepository _vehicleOwnerRepository;
        IUnitOfWork _unitOfWork;

        public ActivateCustomerHandler(ICustomerRepository vehicleOwnerRepository, IUnitOfWork unitOfWork)
        {
            _vehicleOwnerRepository = vehicleOwnerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddVehicleToCustomerCommand request, CancellationToken cancellationToken)
        {
            
            //Can refactor later to use the domain function

            Vehicle vehicle = Vehicle.CreateVehicleFromInput(request.Name,request.PlateNumber,request.Description,request.Color,request.Mileage,request.ImageData,request.CustomerId);

            _vehicleOwnerRepository.AddVehicleToCustomer(request.CustomerId,vehicle);

            _unitOfWork.CommitChanges();
            

            return Unit.Value;
        }
    }

}
