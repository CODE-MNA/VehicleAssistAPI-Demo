using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;

namespace VehicleAssist.Infrastructure.Temporary
{
    public class MockTokenGenerator : ITokenGenerator
    {
        public string GenerateToken(int userID, string email)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("TempToken");
            sb.Append("-");
            sb.Append(userID);
            sb.Append("-");
            sb.Append(email);

            return sb.ToString();
        }
    }
}
