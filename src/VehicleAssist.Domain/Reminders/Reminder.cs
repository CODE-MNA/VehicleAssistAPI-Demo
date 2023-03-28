using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.Domain.Reminders
{
    public class Reminder : BaseEntity
    {
        private Reminder(int reminderId, string name, string description, DateTime reminderDateTime, string serviceType, float latitude, float longitude, int customerId)
        {
            ReminderId = reminderId;
            Name = name;
            Description = description;
            ReminderDateTime = reminderDateTime;
            ServiceType = serviceType;
            Latitude = latitude;
            Longitude = longitude;

            CustomerId = customerId;

        }

        public Reminder(string name, string description, DateTime reminderDateTime, string serviceType, float latitude, float longitude)
        {

            Name = name;
            Description = description;
            ReminderDateTime = reminderDateTime;
            ServiceType = serviceType;
            Latitude = latitude;
            Longitude = longitude;


        }





        public int ReminderId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime ReminderDateTime { get; private set; }

        public List<ReminderAlarmSchedule> ReminderAlarmSchedules {get; set ;}

        public string ServiceType { get; private set; }

        public float Latitude { get; private set; }
        public float Longitude { get; private set; }


        public int CustomerId { get;  set; }
        public Customer.Customer? Customer { get;  set; }

        public void AddSchedule(ReminderAlarmSchedule schedule)
        {
            if(ReminderAlarmSchedules == null)
            {
                ReminderAlarmSchedules = new List<ReminderAlarmSchedule>();
            }
            ReminderAlarmSchedules.Add(schedule);
        }

        public void UpdateReminderData(string name, string description, DateTime reminderDateTime, string serviceType, float latitude, float longitude, List<ReminderAlarmSchedule> newSchedules)
        {
            Name = name;
            Description = description;
            ReminderDateTime = reminderDateTime;
            ServiceType = serviceType;
            Latitude = latitude;
            Longitude = longitude;

            ReminderAlarmSchedules = newSchedules;
        }

        public List<DateTime> GetExtraScheduleDateTimes()
        {
            List<DateTime> schedulingDateTimes = new List<DateTime>();

        

            foreach (var item in ReminderAlarmSchedules)
            {
                DateTime time = ReminderDateTime;

                switch (item.ScheduleType)
                {
                    case ScheduleType.Hours:

                       time = ReminderDateTime.Subtract(TimeSpan.FromHours(item.TimePrior));

                        break;
                    case ScheduleType.Days:
                        time = ReminderDateTime.Subtract(TimeSpan.FromDays(item.TimePrior));
                        break;
                    case ScheduleType.Weeks:
                        time = ReminderDateTime.Subtract(TimeSpan.FromDays(item.TimePrior * 7));

                        break;
                    case ScheduleType.Minutes:
                        time = ReminderDateTime.Subtract(TimeSpan.FromMinutes(item.TimePrior));
                        break;
                    default:
                        
                        break;
                }
                schedulingDateTimes.Add(time);
            }

            return schedulingDateTimes;
        }
    }
}
