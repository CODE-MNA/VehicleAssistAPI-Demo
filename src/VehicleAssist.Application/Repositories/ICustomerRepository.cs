using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer;
using VehicleAssist.Domain.Appointments;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Application.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Domain.Customer.Customer>
    {
        public ICollection<Vehicle> GetAllVehiclesOfCustomer(int customerMemberId);
        public void AddVehicleToCustomer(int customerMemberId,Vehicle vehicle);
        public CalendarData? GetCalenderData(int customerMemberId);
        public void AddReminderToCustomer(int customerMemberId, Reminder reminder);

      
    }
}
