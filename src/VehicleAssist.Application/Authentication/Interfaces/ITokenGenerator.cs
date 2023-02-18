using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Authentication.Interfaces
{
    public interface ITokenGenerator
    {
        public string GenerateToken(int userID,string username, string email);
    }
}
