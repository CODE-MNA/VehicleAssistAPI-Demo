using System.Security.Claims;

namespace VehicleAssist.API.Extensions
{
    public static class AuthenticationExtensions
    {
        public static int GetMemberIdFromClaimsPrincipal(this ClaimsPrincipal user)
        {
          var c =  user.FindFirst((x => x.Type == "member_id"));

            if(c == null)
            {
                throw new Exception("Member Error");
            }

            return int.Parse(c.Value);
        }



    }
}
