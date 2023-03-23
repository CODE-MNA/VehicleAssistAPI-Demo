using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Company;

namespace VehicleAssist.Application.Company
{
    public class DealsDTO
    {
        //how to pass data to the UI and how it will show. Follow VEhicleDTO.cs

        public int DealId { get; set; }
        public string Name { get; private set; }

        public string? Content { get; private set; }

        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }


        public static DealsDTO FromDeal(Deal deal)
        {
            return new DealsDTO()
            {
                DealId= deal.DealId,
                Name = deal.DealName,
                Content = deal.Content,
                StartDate = deal.StartDate,
                EndDate = deal.EndDate,
                CompanyId = deal.CompanyId,
                CompanyName = deal.Company.CompanyName
            };
        }
    }
}
