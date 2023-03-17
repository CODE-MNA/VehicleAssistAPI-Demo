using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VehicleAssist.API.Extensions
{
    public class AuthourizeAsync  : AuthorizeAttribute
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext authorizationFilterContext)
        {
            if (authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {

            }
        }
    }
}
