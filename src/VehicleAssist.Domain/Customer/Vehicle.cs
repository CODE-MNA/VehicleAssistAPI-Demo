using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Domain.Customer
{
    public class Vehicle : BaseEntity
    {
        public Vehicle(int vehicleId, string name, string? plateNumber, string? description, string? color, int? mileage, string? imageLink, int customerId)
        {
            VehicleId = vehicleId;
            Name = name;
            PlateNumber = plateNumber;
            Description = description;
            Color = color;
            Mileage = mileage;
            ImageLink = imageLink;
            CustomerId = customerId;
          
        }

        private Vehicle( string name, string? plateNumber, string? description, string? color, int? mileage, string? imageLink, int customerId)
        {
           
            Name = name;
            PlateNumber = plateNumber;
            Description = description;
            Color = color;
            Mileage = mileage;
            ImageLink = imageLink;
            CustomerId = customerId;

        }

        public static Vehicle CreateVehicleFromInput( string name, string? plateNumber, string? description, string? color, int? mileage, string? imageLink, int customerId)
        {
            
            Vehicle vehicle = new Vehicle(name, plateNumber, description, color, mileage, imageLink, customerId);
            
            return vehicle;
        }

        public void UpdateVehicleData(string name, string? plateNumber, string? description, string? color, int? mileage, string? imageLink)
        {


            Name = name;
            PlateNumber = plateNumber;
            Description = description;
            Color = color;
            Mileage = mileage;
            ImageLink = imageLink;

        }


        public int VehicleId { get; set; }
        public string Name { get; private set; }

        public string? PlateNumber { get; private set; }

        public string? Description { get; private set; }

        public string? Color { get; private set; }

        public int? Mileage { get; private set; }

        public string? ImageLink { get; private set; }


        public int CustomerId { get; set; }
        public Customer? Customer { get; private set; }

        public List<Reminder>? Reminders { get; private set; }
    }
}
