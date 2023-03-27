using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Company;

namespace VehicleAssist.Application.Customer.Queries
{
    public record QueryCustomerCompanyServices: IRequest<CustomerCompanyServicesResults>
    {
    }

    public class GetCustomerCompanyServicesQueryHandler : IRequestHandler<QueryCustomerCompanyServices, CustomerCompanyServicesResults>
    {
        IBaseRepository<CompanyService> _repository;

        public GetCustomerCompanyServicesQueryHandler(IBaseRepository<CompanyService> repository)
        {
            _repository = repository;
        }

        public async Task<CustomerCompanyServicesResults> Handle(QueryCustomerCompanyServices request, CancellationToken cancellationToken)
        {

            List<CompanyService> companyServices = _repository.GetList(null, "Company", "ServiceType", "Discount").ToList();

            List<CompanyServiceDTO> dtos = new List<CompanyServiceDTO>();

            foreach (var companyService in companyServices)
            {
                dtos.Add(CompanyServiceDTO.FromCompanyService(companyService));
            }

            CustomerCompanyServicesResults result = new()
            {
                CompanyServices = dtos,
            };

            return result;
        }

    }

    public record CustomerCompanyServicesResults
    {
        public List<CompanyServiceDTO> CompanyServices { get; set; }
    }
}
