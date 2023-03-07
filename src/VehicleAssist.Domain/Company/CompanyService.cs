using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Appointments;

namespace VehicleAssist.Domain.Company
{
    public class CompanyService
    {
        public int CompanyServiceId { get; private set; }


        public List<Appointment> Appointments { get; private set; }
    }
}
