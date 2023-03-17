using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Appointments;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Application.Customer
{
    public record CalendarData
    {
        public ICollection<Reminder> Reminders { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
