using Microsoft.AspNetCore.Mvc;
using VehicleAssist.API.Extensions;
using VehicleAssist.Application.Company.Queries;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Domain.Company;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleAssist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        // GET: api/Company/{id}/Deals
        //will do the connections in companyController.
        [HttpGet("company/deal/{id}")]
        public IEnumerable<string> GetCompanyDeals(int companyId)
        {

            return companyId.ToString().Split(',');
            //int possibleCompanyId = Company();

            //CompanyDealsResults result = await _mediator.Send(new QueryCompanyDeals() { CompanyId = possibleCompanyId });

            //return new JsonResult(result);
        }

    }
}
