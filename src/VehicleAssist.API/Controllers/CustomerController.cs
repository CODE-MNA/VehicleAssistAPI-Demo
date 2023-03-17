using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleAssist.API.Extensions;
using VehicleAssist.APIContracts;
using VehicleAssist.Application.Customer.Commands;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Domain.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleAssist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("vehicles")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetCustomerVehicles()
        {
           int possibleCustomerId =  User.GetMemberIdFromClaimsPrincipal();
            
            

            VehiclesFromCustomerQueryResult result = await _mediator.Send(new GetVehiclesFromCustomer() { CustomerId = possibleCustomerId}) ;
            
            return new JsonResult(result);

            
        }

        [HttpPost("vehicles")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddCustomerVehicle([FromBody]AddVehicleRequest request)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();

            AddVehicleToCustomerCommand command = new AddVehicleToCustomerCommand()
            {
                CustomerId = possibleCustomerId,
                Color = request.Color,
                Description = request.Description,
                ImageData = request.ImageLink,
                Mileage = request.Mileage,
                Name = request.Name,
                PlateNumber = request.PlateNumber


            };


            await _mediator.Send(command);

            return Ok();


        }


        [HttpGet("calendar")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetCalendarData()
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();



            CalendarFromCustomerQueryResult result = await _mediator.Send(new GetCalendarDataFromCustomer() { CustomerId = possibleCustomerId });

            return new JsonResult(result);


        }



        [HttpPost("reminders")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddReminderToCustomer([FromBody] AddReminderRequest request)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();



            var result = await _mediator.Send(new AddReminderForCustomerCommand() 
            { 
                CustomerId = possibleCustomerId,
                ReminderDateTime = request.ReminderDateTime,
                Description = request.Description,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Name = request.Name,
                ServiceType = request.ServiceType,


            });

            return  Ok();


        }


        // PUT api/<CustomerController>/vehicle/:id
        [HttpPut("{id}")]
        [Authorize(Roles = "Customer")]

        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/vehicle/:id
        [HttpDelete("{id}")]
        [Authorize(Roles = "Customer")]
        public void Delete(int id)
        {
        }


       [Authorize]
        [HttpGet]
        public IActionResult GetAllCustomerData()
        {
            Console.WriteLine(HttpContext.Request.Headers.Authorization);

            foreach (var item in User.Claims)
            {
                Console.WriteLine(item.Value);
            }

            int possibleCustomer = User.GetMemberIdFromClaimsPrincipal();

            return Ok(new { loggedInCustomerId = possibleCustomer });
        }
    }
}
