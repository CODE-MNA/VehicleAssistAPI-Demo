using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleAssist.APIContracts;
using VehicleAssist.Application.Authentication.Commands;
using VehicleAssist.Application.Authentication.Queries.Login;
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
                username = request.username,
                password = request.password,
            };

                LoginQueryResult result = await _mediator.Send(query);
                return new JsonResult(result);


       
        }

        [HttpPost("auth/local/[action]")]
        public async Task<IActionResult> RegisterCustomer(CustomerRegisterRequest request)
        {
            
            if (request == null) return BadRequest();


            //Custom mapping (more control)
            RegisterCommand command = new RegisterCommand()
            {
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                IsCompany = false
            };
           

                RegisterCustomerCommandResult result = await _mediator.Send(command);
                return new JsonResult(result);



        }

        [HttpPost("auth/local/[action]")]
        public async Task<IActionResult> RegisterCompany(CompanyRegisterRequest request)
        {

            if (request == null) return BadRequest();

            


            //Custom mapping (more control)
            RegisterCommand command = new RegisterCommand()
            {
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                CompanyDescription = request.CompanyDescription,
                CompanyName = request.CompanyName,
                IsCompany = true
            };


                RegisterCustomerCommandResult result = await _mediator.Send(command);
                return new JsonResult(result);



        }


        [HttpGet("auth/local/[action]/{token}")]
        public async Task<IActionResult> Activate(string token)
        {

            if (token == null) return BadRequest();


            ActivateCustomerCommand request = new ActivateCustomerCommand()
            {
                Token = token
            };

        
                 await _mediator.Send(request);
                return Ok();


        }

    }
}
