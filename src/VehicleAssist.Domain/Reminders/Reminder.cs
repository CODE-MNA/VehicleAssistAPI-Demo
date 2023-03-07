using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Reminders
{
    public class Reminder
    {
        public int ReminderId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime ReminderDateTime { get; private set; }

        //Enum : Servvice type
        public string ServiceType { get; private set; }

        public float Latitude { get; private set; }
        public float Longitude { get; private set; }


    }
}
