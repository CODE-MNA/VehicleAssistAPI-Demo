using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleAssist.API.Extensions;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Domain.Company;

//Not Implemented

namespace VehicleAssist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
