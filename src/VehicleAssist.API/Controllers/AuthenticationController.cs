using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleAssist.APIContracts;
using VehicleAssist.Application.Authentication;
using VehicleAssist.Application.Authentication.Queries;

namespace VehicleAssist.API.Controllers
{

    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("auth/local/[action]")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request == null) return BadRequest();

            LoginQuery query = new LoginQuery()
            {
                email = request.email,
                password = request.password,
            };

            try
            {
                LoginQueryResult result = await _mediator.Send(query);
                return new JsonResult(result);


            }
            catch (Exception ex)
            {
                //TODO : USE A ERROR HANDLER FUNCTION WHICH TAKES IN DOMAIN EXCEPTION AND RETURNS ERROR
                //IN A CONSUMABLE FORMAT

                return BadRequest(ex.Message);  
            }

        }
    }
}
