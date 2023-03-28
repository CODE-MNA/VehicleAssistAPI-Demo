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

        // Main Data
        public float TimePrior { get; set; }
        public ScheduleType ScheduleType { get; set; }

        //Navigation
        public int ReminderId { get; set; }
        public Reminder? Reminder { get; set; }

        public static ReminderAlarmSchedule CreateReminderSchedule(int forReminderId,float timePrior, string scheduleTypeString)
        {
            ReminderAlarmSchedule schedule = new ReminderAlarmSchedule();

            schedule.TimePrior = timePrior;
            schedule.ReminderId = forReminderId;

            if(Enum.TryParse<ScheduleType>(scheduleTypeString,out ScheduleType scheduleType)){
                schedule.ScheduleType = scheduleType;
            }else
            {
                throw new IncorrectScheduleTypeException(scheduleTypeString + " is an incorrect schedule type!");
            }

            return schedule;
        }
        public static ReminderAlarmSchedule CreateReminderSchedule( float timePrior, string scheduleTypeString)
        {
            ReminderAlarmSchedule schedule = new ReminderAlarmSchedule();

            schedule.TimePrior = timePrior;
       

            if (Enum.TryParse<ScheduleType>(scheduleTypeString, out ScheduleType scheduleType))
            {
                schedule.ScheduleType = scheduleType;
            }
            else
            {
                throw new IncorrectScheduleTypeException(scheduleTypeString + " is an incorrect schedule type!");
            }

            return schedule;
        }


  
    }


    public enum ScheduleType
    {
        Hours,Days,Weeks,Minutes

    }
}
