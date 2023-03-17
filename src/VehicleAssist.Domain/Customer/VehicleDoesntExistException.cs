using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Customer
{
    public class VehicleDoesntExistException : AbstractDomainException
    {
        public VehicleDoesntExistException(string? exception) : base(exception)
        {
        }
    }
}
