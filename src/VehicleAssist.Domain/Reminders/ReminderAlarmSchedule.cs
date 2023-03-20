using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Reminders
{
    public class ReminderAlarmSchedule : BaseEntity
    {
        public int ReminderAlarmScheduleId { get; set; }

        public int ReminderId { get; set; }
        public Reminder Reminder { get; set; }

        public float TimePrior { get; set; }
        public ScheduleType ScheduleType { get; set; }

    }


    public enum ScheduleType
    {
        Hours,Days,Weeks,Minutes
    }
}
