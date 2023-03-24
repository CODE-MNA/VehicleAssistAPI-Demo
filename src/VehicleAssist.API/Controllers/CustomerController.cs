using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleAssist.API.Extensions;
using VehicleAssist.APIContracts;
using VehicleAssist.Application.Customer;
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


        #region Vehicles

        [HttpGet("vehicles")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetCustomerVehicles()
        { // get user id from token
           int possibleCustomerId =  User.GetMemberIdFromClaimsPrincipal();
            
            

            VehiclesFromCustomerQueryResult result = await _mediator.Send(new GetVehiclesFromCustomer() { CustomerId = possibleCustomerId}) ;
            
            return new JsonResult(result);

            
        }

        [HttpGet("vehicles/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetVehicleDetails(int id)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();


            int vehicleId = id;


            var result = await _mediator.Send(new VehicleDetailsQuery()
            {
                CustomerId = possibleCustomerId,
                VehicleId = vehicleId
            });

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

        #endregion

        #region Reminders

        [HttpGet("calendar")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetCalendarData()
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();



            CalendarFromCustomerQueryResult result = await _mediator.Send(new GetCalendarDataFromCustomer() { CustomerId = possibleCustomerId });

            return new JsonResult(result);


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





        [HttpPost("reminders")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddReminderToCustomer([FromBody] AddReminderRequest request)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();

            List<ReminderScheduleDTO> inputSchedules = new List<ReminderScheduleDTO>();

            if(request.Schedules != null) {
                foreach (var item in request.Schedules)
                {
                    var entry = new ReminderScheduleDTO(item.TimeBefore, item.ScheduleType);
                    inputSchedules.Add(entry);
                }
            }

            

         
            await _mediator.Send(new AddReminderForCustomerCommand() 
            { 
                CustomerId = possibleCustomerId,
                ReminderDateTime = request.ReminderDateTime,
                Description = request.Description,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Name = request.Name,
                ServiceType = request.ServiceType,
                ReminderSchedules = inputSchedules
                
                

            });

            return  Ok();


        }

        [HttpPut("reminders/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateReminder([FromRoute]int id,[FromBody] AddReminderRequest request)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();

            List<ReminderScheduleDTO> inputSchedules = new List<ReminderScheduleDTO>();

            if (request.Schedules != null)
            {
                foreach (var item in request.Schedules)
                {
                    var entry = new ReminderScheduleDTO(item.TimeBefore, item.ScheduleType);
                    inputSchedules.Add(entry);
                }
            }




            await _mediator.Send(new UpdateReminderCommand()
            {
                ReminderId = id,
                CustomerId = possibleCustomerId,
                ReminderDateTime = request.ReminderDateTime,
                Description = request.Description,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Name = request.Name,
                ServiceType = request.ServiceType,
                ReminderSchedules = inputSchedules



            });

            return Ok();


        }


        [HttpDelete("reminders/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            int possibleCustomerId = User.GetMemberIdFromClaimsPrincipal();
            int reminderId = id;


            await _mediator.Send(new DeleteReminderCommand()
            {
              ReminderId = reminderId,
                CustomerId = possibleCustomerId
            });

            return Ok();


        }

        [HttpGet("deals")]
        public async Task<IActionResult> GetCompanyDeals()
        {

            CustomerDealsResults result = await _mediator.Send(new QueryCustomerDeals() { });

            return new JsonResult(result);
        }
        #endregion



    }
}
