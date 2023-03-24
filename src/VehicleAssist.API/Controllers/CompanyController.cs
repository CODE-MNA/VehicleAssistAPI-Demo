using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleAssist.API.Extensions;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Domain.Company;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
