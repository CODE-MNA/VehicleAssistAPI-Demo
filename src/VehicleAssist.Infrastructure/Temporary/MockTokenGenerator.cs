using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Infrastructure.Temporary
{
    public class MockTokenGenerator : ITokenGenerator
    {
        public string GenerateToken(Member member)
        {
            int userID = member.MemberId;
                string email = member.Email;
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
