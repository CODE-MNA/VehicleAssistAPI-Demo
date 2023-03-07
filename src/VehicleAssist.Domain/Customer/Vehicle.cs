using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Customer
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Name { get; private set; }

        public string? PlateNumber { get; private set; }

        public string? Description { get; private set; }

        public string? Color { get; private set; }

        public int? Mileage { get; private set; }

        public string? ImageLink { get; private set; }


        public int CustomerId { get; set; }
        public Customer? Customer { get; private set; }


    }
}
