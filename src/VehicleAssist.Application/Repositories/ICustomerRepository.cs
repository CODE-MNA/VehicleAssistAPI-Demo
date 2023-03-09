using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.Application.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public ICollection<Vehicle> GetAllVehiclesOfCustomer(int customerMemberId);
        
    }
}
