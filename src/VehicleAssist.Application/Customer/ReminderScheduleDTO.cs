using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Application.Customer
{
    public class ReminderScheduleDTO
    {
        public float TimePrior { get; set; }
        public string ScheduleType { get; set; }


        public ReminderScheduleDTO(float timePrior, string scheduleType)
        {
            TimePrior = timePrior;
            if (string.IsNullOrEmpty(scheduleType))
            {

                ScheduleType = string.Empty;
            }
            else
            {

            char[] chars = scheduleType.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            ScheduleType =  new string(chars);




            }

      

        }
    }
}
