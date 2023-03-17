using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.Application.Customer
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string Name { get; private set; }

        public string? PlateNumber { get; private set; }

        public string? Description { get; private set; }

        public string? Color { get; private set; }

        public int? Mileage { get; private set; }

        public string? ImageLink { get; private set; }






        public static VehicleDTO FromVehicle(Vehicle vehicle)
        {
            return new VehicleDTO()
            {
                VehicleId = vehicle.VehicleId,
                Name = vehicle.Name,
                PlateNumber = vehicle.PlateNumber,
                Description = vehicle.Description,
                Color = vehicle.Color,
                Mileage = vehicle.Mileage,
                ImageLink = vehicle.ImageLink,
            
            };
        }
    }
}
