using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Infrastructure.Data;
using VehicleAssist.Domain.Customer;
using Microsoft.EntityFrameworkCore;

namespace VehicleAssist.Infrastructure.CustomerServices
{
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(VehicleAssistDBContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Vehicle> GetAllVehiclesOfCustomer(int customerMemberId)
        {
            return _dbContext.Vehicles.Where(v => v.CustomerId == customerMemberId).ToList().AsReadOnly();
        }

        public void AddVehicle(int customerMemberId, Vehicle vehicle)
        {
            vehicle.CustomerId = customerMemberId;
            _dbContext.Vehicles.Add(vehicle);
        }

        
    }
}
