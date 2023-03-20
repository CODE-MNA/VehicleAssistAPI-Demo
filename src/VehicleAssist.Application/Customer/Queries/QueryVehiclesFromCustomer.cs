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
    public record GetVehiclesFromCustomer : IRequest<VehiclesFromCustomerQueryResult>
    {
        public int CustomerId { get; set; }
    }

    public class GetVehiclesFromCustomerQueryHandler : IRequestHandler<GetVehiclesFromCustomer, VehiclesFromCustomerQueryResult>
    {

        ICustomerRepository _customerRepository;

        public GetVehiclesFromCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<VehiclesFromCustomerQueryResult> Handle(GetVehiclesFromCustomer request, CancellationToken cancellationToken)
        {
            //Customer has vehicles

            int customerId = request.CustomerId;

            List<Vehicle> vehicles =  _customerRepository.GetAllVehiclesOfCustomer(customerId).ToList();

            List<VehicleDTO> dtos = new List<VehicleDTO>();
            foreach (var vehicle in vehicles)
            {
                dtos.Add(VehicleDTO.FromVehicle(vehicle));
            } 
            
             VehiclesFromCustomerQueryResult result = new()
             {
                 Vehicles =dtos ,
             };

            return result;

        }
    }

    public record VehiclesFromCustomerQueryResult
    {
        public List<VehicleDTO> Vehicles { get; set; }
    }
}
