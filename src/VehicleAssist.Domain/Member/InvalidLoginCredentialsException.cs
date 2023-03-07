using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Member
{
    public class InvalidLoginCredentialsException : AbstractDomainException
    {
        public InvalidLoginCredentialsException(string exception) : base(exception)
        {
        }
    }
}
