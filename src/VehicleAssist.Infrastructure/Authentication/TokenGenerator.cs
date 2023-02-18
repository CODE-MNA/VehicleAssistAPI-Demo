using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;

namespace VehicleAssist.Infrastructure.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(int userID, string username, string email)
        {
         
            throw new NotImplementedException();    
        }
    }
}
