using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Member
{
    public class LoginEmailNotFoundException : AbstractDomainException
    {
        public LoginEmailNotFoundException(string exception) : base(exception)
        {
        }
    }
}
