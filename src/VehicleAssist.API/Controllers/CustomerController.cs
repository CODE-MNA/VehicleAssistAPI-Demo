using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReminderAssist.Application.Customer.Queries;
using VehicleAssist.API.Extensions;
using VehicleAssist.APIContracts;
using VehicleAssist.Application.Customer.Commands;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Domain;

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
        { // get user id from token
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

        [HttpGet("vehicles/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetVehicleDetails(int id)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();


            int vehicleId = id;


          var result =  await _mediator.Send(new VehicleDetailsQuery()
            {
                CustomerId=possibleCustomerId,
                VehicleId=vehicleId
            });

            return new JsonResult(result);


        }


        [HttpDelete("vehicles/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();

         

            int vehicleId = id;


            await _mediator.Send(new DeleteVehicleCommand()
            {
                VehicleId = vehicleId,
                CustomerId = possibleCustomerId
            });

            return Ok();


        }


        [HttpPut("vehicles/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateVehicleInformation([FromRoute] int id,[FromBody] AddVehicleRequest request)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();

            if (id == 0)
            {
                throw new AbstractDomainException("Enter proper vehicle ID");
            }

            var command = new UpdateVehicleInformationCommand()
            {
                VehicleId = id,
                Description = request.Description,
                Color = request.Color,
                CustomerId = possibleCustomerId,
                ImageLink = request.ImageLink,
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



            await _mediator.Send(new AddReminderForCustomerCommand() 
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


        [HttpGet("reminders/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetReminderDetails(int id)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();


            int reminderId = id;


            var result = await _mediator.Send(new ReminderDetailsQuery()
            {
                CustomerId = possibleCustomerId,
                ReminderId = reminderId
            });

            return new JsonResult(result);


        }


        // // PUT api/<CustomerController>/vehicle/:id
        // [HttpPut("{id}")]
        // [Authorize(Roles = "Customer")]

        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/<CustomerController>/vehicle/:id
        // [HttpDelete("{id}")]
        // [Authorize(Roles = "Customer")]
        // public void Delete(int id)
        // {
        // }


        //[Authorize]
        // [HttpGet]
        // public IActionResult GetAllCustomerData()
        // {
        //     Console.WriteLine(HttpContext.Request.Headers.Authorization);

        //     foreach (var item in User.Claims)
        //     {
        //         Console.WriteLine(item.Value);
        //     }

        //     int possibleCustomer = User.GetMemberIdFromClaimsPrincipal();

        //     return Ok(new { loggedInCustomerId = possibleCustomer });
        // }
    }
}
