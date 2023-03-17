using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Customer
{
    public class CustomerDoesntExistException : AbstractDomainException
    {
        public CustomerDoesntExistException(string? exception) : base(exception)
        {
          
        }
    }
}
