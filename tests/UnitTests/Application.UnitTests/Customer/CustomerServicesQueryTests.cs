using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Company;
using Xunit;

namespace Application.UnitTests.Customer
{
    public class CustomerServicesQueryTests
    {
        Mock<IBaseRepository<CompanyService>> _repository;

        public CustomerServicesQueryTests()
        {
            _repository = new Mock<IBaseRepository<CompanyService>>();
        }

        [Fact]
        public async Task Handle_ShouldReturnTwoDTOs_QueryingWhenTwoServicesInRepo()
        {

            //Arrange
            ICollection<CompanyService> services = new List<CompanyService>();

            CompanyService service = new CompanyService();
            CompanyService service2 = new CompanyService();

            services.Add(service);
            services.Add(service2);

            _repository.Setup(r => r.GetList(null, It.IsAny<string[]>()))
                .Returns(services);


            var query = new QueryCustomerCompanyServices();

            var handler = new GetCustomerCompanyServicesQueryHandler(_repository.Object);

            //Act 
            var result = await handler.Handle(query, default);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2,result.CompanyServices.Count);
      
        }

        [Fact]
        public async Task Handle_ShouldReturnValidDTO_ShouldMatchCompanyServiceEntity()
        {
            List<CompanyService> deals = new List<CompanyService>();

      
            const string description = "This is the service";
            const int memberId = 1;


            const string serviceCode = "32F";
            const int actualPrice = 40;
            const string serviceName = "VehicleChange";
            const string discountTypeCode = "Percentage";
            const int discountAmount = 20;
            const int price = 50;
            CompanyService deal1 = new CompanyService()
            {
                ServiceTypeCode = serviceCode,
                ActualPrice = actualPrice,
                Name= serviceName,
                DiscountTypeCode = discountTypeCode,
                DiscountAmount = discountAmount,
                Price = price,
              Description =  description,
                MemberId = memberId,
            };

            deals.Add(deal1);



            //Arrange
            _repository.Setup(r => r.GetList(null,It.IsAny<string[]>()))
                .Returns(deals);


            var query = new QueryCustomerCompanyServices();

            var handler = new GetCustomerCompanyServicesQueryHandler(_repository.Object);

            //Act 
            var result = await handler.Handle(query, default);

            //Assert
            Assert.Equal(memberId,result.CompanyServices[0].MemberId);
            Assert.Equal(serviceCode, result.CompanyServices[0].ServiceTypeCode);
            Assert.Equal(actualPrice, result.CompanyServices[0].ActualPrice);
            Assert.Equal(serviceName, result.CompanyServices[0].Name);
            Assert.Equal(discountTypeCode, result.CompanyServices[0].DiscountTypeCode);
            Assert.Equal(discountAmount, result.CompanyServices[0].DiscountAmount);
            Assert.Equal(price, result.CompanyServices[0].Price);
            Assert.Equal(description, result.CompanyServices[0].Description);



        }
    }
}
