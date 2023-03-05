using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Domain.Customer
{
    public class Customer : Member.Member
    {


        List<Vehicle> vehicles;
        List<Reminder> reminders;

        //appointments

        //TODO : Take Parameters in this function
        public void AddNewVehicle()
        {
            Vehicle vehicle = new Vehicle();

            vehicles.Add(vehicle);
        }
    }
}
