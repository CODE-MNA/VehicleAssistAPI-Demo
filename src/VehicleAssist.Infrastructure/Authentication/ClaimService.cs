using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.Infrastructure.Authentication
{
    public class ClaimService : IClaimService
    {
        IHttpContextAccessor _contextAccessor;

        public Customer GetCustomerFromClaim()
        {
            throw new NotImplementedException();
        }
    }
}
