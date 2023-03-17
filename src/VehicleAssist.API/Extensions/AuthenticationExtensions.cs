using System.Security.Claims;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.API.Extensions
{
    public static class AuthenticationExtensions
    {
        public static int GetMemberIdFromClaimsPrincipal(this ClaimsPrincipal user)
        {
          var c =  user.FindFirst((x => x.Type == "member_id"));

            if(c == null)
            {
                throw new CustomerDoesntExistException("Customer Request Error");
            }

           int num =  int.Parse(c.Value);

            if(num <= 0)
            {
                throw new CustomerDoesntExistException("Customer Request Error");
            }
            return num ;
        }



    }
}
