using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.APIContracts
{
    public record AddVehicleRequest
    {

        public string Name { get; set; } = "";
        public string? PlateNumber { get;  set; }

        public string? Description { get;  set; }

        public string? Color { get;  set; }

        public int? Mileage { get;  set; }

        public string? ImageLink { get;  set; }



    }
}
