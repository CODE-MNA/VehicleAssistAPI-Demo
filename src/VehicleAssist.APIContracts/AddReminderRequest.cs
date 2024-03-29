﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.APIContracts
{
    public record AddReminderRequest 
    {



        public string Name { get; set; }

        public string Description { get; set; }

        // LocalDate LocalTime OffsetFromUTCOfThatLocalTime
        public DateTime ReminderDateTime { get; set; }

        public string TimeZoneOffset { get; set; }

        public string ServiceType { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }
    
        public List<ReminderSchedule>? Schedules { get; set; }
        


     


    }

    public struct ReminderSchedule
    {
        public float TimeBefore { get; set; }
        public string ScheduleType { get; set; }
    }

}
