using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Reminders
{
    internal class IncorrectScheduleTypeException : AbstractDomainException
    {
        public IncorrectScheduleTypeException(string? exception) : base(exception)
        {
        }
    }
}
