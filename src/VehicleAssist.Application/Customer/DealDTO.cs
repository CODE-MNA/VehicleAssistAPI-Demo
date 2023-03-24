using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Company;

namespace VehicleAssist.Application.Customer
{
    public class DealDTO
    {
        public int DealId { get; set; }
        public string Name { get; private set; }

        public string? Content { get; private set; }

        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public int MemberId { get; set; }

        public string? CompanyName { get; set; }


        public static DealDTO FromDeal(Deal deal)
        {
            return new DealDTO()
            {
                DealId = deal.DealId,
                Name = deal.DealName,
                Content = deal.Content,
                StartDate = deal.StartDate,
                EndDate = deal.EndDate,
                MemberId = deal.MemberId,
                CompanyName = deal.Company.CompanyName,
            };
        }
    }
}
