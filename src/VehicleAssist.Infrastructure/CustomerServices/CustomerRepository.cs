using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Infrastructure.Data;
using VehicleAssist.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using VehicleAssist.Domain.Reminders;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Application.Customer;
using VehicleAssist.Domain.Appointments;

namespace VehicleAssist.Infrastructure.CustomerServices
{
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(VehicleAssistDBContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Vehicle> GetAllVehiclesOfCustomer(int customerMemberId)
        {
            return _dbContext.Vehicles.AsNoTracking().Where(v => v.CustomerId == customerMemberId).ToList().AsReadOnly();
        }

        public void AddVehicleToCustomer(int customerMemberId, Vehicle vehicle)
        {
            vehicle.CustomerId = customerMemberId;
            _dbContext.Vehicles.Add(vehicle);
        }


        public CalendarData? GetCalenderData(int customerMemberId)
        {
            Customer customer = _dbContext.Customers.Find(customerMemberId);

            if (customer != null)
            {
                _dbContext.Entry(customer).Collection(q => q.Appointments).Load();
                _dbContext.Entry(customer).Collection(q => q.Reminders).Load();

                return new CalendarData()
                {
                    Appointments = customer.Appointments,
                    Reminders = customer.Reminders
                };
            }

            return null;

           


        }

        public void AddReminderToCustomer(int customerMemberId, Reminder reminder)
        {
        
            reminder.CustomerId = customerMemberId;
            _dbContext.Reminders.Add(reminder);
        }
     
    }
}
