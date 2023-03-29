using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Company;

namespace VehicleAssist.Application.Customer
{
    public class CompanyServiceDTO
    {
        public int CompanyServiceId { get; set; }

        public int MemberId { get; set; }

        public string ServiceTypeCode { get; set; }
        public string ServiceDescription { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string DiscountTypeCode { get; set; }

        public int DiscountDescription { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal ActualPrice { get; set; }

        public string CompanyName { get; set; }

        public static CompanyServiceDTO FromCompanyService(CompanyService companyService)
        {
            return new CompanyServiceDTO()
            {
                CompanyServiceId = companyService.CompanyServiceId,
                MemberId = companyService.MemberId,
                CompanyName = companyService.Company.CompanyName,
                ServiceTypeCode = companyService.ServiceTypeCode,
                ServiceDescription = companyService.ServiceType.Description,
                Name = companyService.Name,
                Description = companyService.Description,
                Price = companyService.Price,
                DiscountTypeCode = companyService.DiscountTypeCode,
                DiscountDescription = companyService.Discount.Description,
                DiscountAmount = companyService.DiscountAmount,
                ActualPrice = companyService.ActualPrice,

            };
        }
    }
}
