using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Application.Customer
{
    public class ReminderDTO
    {
        public ReminderDTO(int reminderId, string name, string description, DateTime reminderDateTime, string serviceType, float latitude, float longitude)
        {
            ReminderId = reminderId;
            Name = name;
            Description = description;
            ReminderDateTime = new DateTime(reminderDateTime.Ticks,DateTimeKind.Utc);
            ServiceType = serviceType;
            Latitude = latitude;
            Longitude = longitude;


        }

        public int ReminderId { get;  set; }

        public string Name { get;  set; }

        public string Description { get;  set; }

        public DateTime ReminderDateTime { get;  set; }


        public string ServiceType { get;  set; }

        public float Latitude { get;  set; }
        public float Longitude { get;  set; }

        public List<ReminderScheduleDTO> Schedules { get; set; } = new List<ReminderScheduleDTO>();


        public static ReminderDTO FromReminder(Reminder reminder)
        {
         

            var dto = new ReminderDTO(reminder.ReminderId, reminder.Name, reminder.Description, reminder.ReminderDateTime,
                reminder.ServiceType, reminder.Latitude, reminder.Longitude);

            if(reminder.ReminderAlarmSchedules == null)
            {
                return dto;
            }
      
            foreach (var time in reminder.ReminderAlarmSchedules)
            {
                var newschedule = new ReminderScheduleDTO(time.TimePrior, time.ScheduleType.ToString());
                dto.Schedules.Add(newschedule);
            }

            

            return dto;
        }

    }
}
