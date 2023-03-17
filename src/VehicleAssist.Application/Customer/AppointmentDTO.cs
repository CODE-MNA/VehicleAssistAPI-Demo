using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Appointments;

namespace VehicleAssist.Application.Customer
{
    public class AppointmentDTO
    {
        public AppointmentDTO(int appointmentId, DateTime startDateTime, DateTime endDateTime)
        {
            AppointmentId = appointmentId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public int AppointmentId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }


        public static AppointmentDTO FromAppointment(Appointment appointment)
        {
            var dto = new AppointmentDTO(appointment.AppointmentId, appointment.StartDateTime, appointment.EndDateTime);

            return dto;
        }
    }
}
