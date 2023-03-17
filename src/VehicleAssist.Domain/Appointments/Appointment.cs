using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Appointments
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool AlarmYN { get; set; }

        public int CustomerId { get; set; }
        public Customer.Customer? Customer { get; set; }

        public int CompanyServiceId { get; set; }
        public Company.CompanyService? CompanyService { get; set; }

        
        //ADD Member and Service
    }
}
