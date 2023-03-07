using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleAssist.APIContracts;
using VehicleAssist.Application.Authentication;
using VehicleAssist.Application.Authentication.Commands;
using VehicleAssist.Application.Authentication.Queries;
using VehicleAssist.Domain;

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

        [HttpPost("auth/local/[action]")]
        public async Task<IActionResult> Register(CustomerRegisterRequest request)
        {
            
            if (request == null) return BadRequest();


            //Custom mapping (more control)
            RegisterCustomerCommand command = new RegisterCustomerCommand()
            {
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
            };
           

            try
            {
                RegisterCustomerCommandResult result = await _mediator.Send(command);
                return Ok();


            } // Catch a summarized exception
            catch (AbstractDomainException ex)
            {
                //TODO : USE A ERROR HANDLER FUNCTION WHICH TAKES IN DOMAIN EXCEPTION AND RETURNS ERROR
                //IN A CONSUMABLE FORMAT

                Dictionary<string, string> errors = new Dictionary<string, string>();

                errors.Add("ErrorName", ex.ExceptionName);
                errors.Add("Message",ex.Message);

                return BadRequest(errors);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
