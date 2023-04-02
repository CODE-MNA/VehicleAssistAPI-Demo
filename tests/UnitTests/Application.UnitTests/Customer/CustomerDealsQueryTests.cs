using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Company;
using Xunit;

namespace Application.UnitTests.Customer
{
    public class CustomerDealsQueryTests
    {
        Mock<IBaseRepository<Deal>> _repository;

        public CustomerDealsQueryTests()
        {
            _repository = new Mock<IBaseRepository<Deal>>();
        }

        [Fact]
        public async Task Handle_ShouldReturnTwoDTOs_QueryingWhenTwoDealsInRepo()
        {
            List<Deal> deals = new List<Deal>();
            

           Deal deal1 = new Deal()
           {
               DealId = 1,
               DealName = "Deal 1",
               StartDate = DateTime.Now,
               EndDate = DateTime.Now.AddDays(5),
               Content = "This is the first deal",
               MemberId = 1,
           };

            Deal deal2 = new Deal()
            {
                DealId = 1,
                DealName = "Deal 2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                Content = "This is the first deal",
                MemberId = 1,
            };
            deals.Add(deal1);
            deals.Add(deal2);


            //Arrange
            _repository.Setup(r => r.GetList(null,It.IsAny<string>()))
                .Returns(deals);


            var query= new QueryCustomerDeals();

            var handler = new GetCustomerDealsQueryHandler(_repository.Object);

            //Act 
            var result = await handler.Handle(query,default);

            //Assert
            Assert.Equal(2,result.Deals.Count);
            Assert.IsType<DealDTO>(result.Deals[0]);
            Assert.IsType<DealDTO>(result.Deals[1]);
        }

        [Fact]
        public async Task Handle_ShouldReturnValidDTO_ShouldMatchDealEntity()
        {
            List<Deal> deals = new List<Deal>();

            int dealId = 1;
            string dealName = "Deal 1";
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(5);
            const string content = "This is the first deal";
            const int memberId = 1;


            Deal deal1 = new Deal()
            {
                DealId = dealId,
                DealName = dealName,
                StartDate = startDate,
                EndDate = endDate,
                Content = content,
                MemberId = memberId,
            };

            deals.Add(deal1);
          


            //Arrange
            _repository.Setup(r => r.GetList(null, It.IsAny<string>()))
                .Returns(deals);


            var query = new QueryCustomerDeals();

            var handler = new GetCustomerDealsQueryHandler(_repository.Object);

            //Act 
            var result = await handler.Handle(query, default);

            //Assert
            Assert.Equal(dealName, result.Deals[0].Name);
            Assert.Equal(startDate, result.Deals[0].StartDate);
            Assert.Equal(endDate, result.Deals[0].EndDate);
            Assert.Equal(content, result.Deals[0].Content);
            Assert.Equal(memberId, result.Deals[0].MemberId);
            Assert.Equal(dealId, result.Deals[0].DealId);
         
        }

    }
}
