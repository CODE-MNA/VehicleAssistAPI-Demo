using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Authentication.Interfaces
{
    public interface IClaimService
    {
        public Domain.Customer.Customer GetCustomerFromClaim();
    }
}
