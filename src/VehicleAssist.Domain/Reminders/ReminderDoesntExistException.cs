using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Reminders
{
    public class ReminderDoesntExistException : AbstractDomainException
    {
        public ReminderDoesntExistException(string? exception) : base(exception)
        {
        }
    }
}
