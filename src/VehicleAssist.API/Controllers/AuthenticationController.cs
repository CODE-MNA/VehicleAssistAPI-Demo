using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAssist.APIContracts;

namespace VehicleAssist.API.Controllers
{

    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost("auth/local/[action]")]
        public IActionResult Login(LoginRequest request)
        {
            if (request == null) return BadRequest();

            //Use Application Project's Auth service 
            ////or command handler with mediator
            //// to login



            return Ok();
        }
    }
}
