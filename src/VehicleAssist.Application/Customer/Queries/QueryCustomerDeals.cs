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
    public record QueryCustomerDeals: IRequest<CustomerDealsResults>
    {
    }

    public class GetCustomerDealsQueryHandler: IRequestHandler<QueryCustomerDeals, CustomerDealsResults>
    {
        IBaseRepository<Deal> _repository;

        public GetCustomerDealsQueryHandler(IBaseRepository<Deal> repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDealsResults> Handle(QueryCustomerDeals request, CancellationToken cancellationToken)
        {

            List<Deal> deals = _repository.GetList(null, "Company").ToList();

            List<DealDTO> dtos = new List<DealDTO>();

            foreach (var deal in deals)
            {
                dtos.Add(DealDTO.FromDeal(deal));
            }

            CustomerDealsResults result = new()
            {
                Deals = dtos,
            };

            return result;
        }
    }

    public record CustomerDealsResults
    {
        public List<DealDTO> Deals { get; set; }
    }
}
