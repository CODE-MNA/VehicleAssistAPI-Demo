using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.Application.Company.Queries
{
    public record QueryCompanyDeals : IRequest<CompanyDealsResults>
    {
        public int CompanyId { get; set; }
    }

    public class GetCompanyDealsQueryHandler : IRequestHandler<QueryCompanyDeals, CompanyDealsResults>
    {

        IBaseRepository<Deal> _repository;

        public GetCompanyDealsQueryHandler(IBaseRepository<Deal> repository)
        {
            _repository = repository;
        }

        public async Task<CompanyDealsResults> Handle(QueryCompanyDeals request, CancellationToken cancellationToken)
        {

            List<Deal>  deals = _repository.GetList(c=>c.CompanyId == request.CompanyId).ToList();

            List<DealsDTO> dtos = new List<DealsDTO>();

            foreach (var deal in deals)
            {
                dtos.Add(DealsDTO.FromDeal(deal));

            }

            CompanyDealsResults result = new()
            {
                Deals = dtos,
            };

            return result;
        }
    }

    public record CompanyDealsResults
    {
        public List<DealsDTO> Deals { get; set; }
    }
}
