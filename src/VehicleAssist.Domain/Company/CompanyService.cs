using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Appointments;
using VehicleAssist.Domain.Service;

namespace VehicleAssist.Domain.Company
{
    public class CompanyService:BaseEntity
    {
        public int CompanyServiceId { get; private set; }

        public int MemberId { get; set; }

        public string ServiceTypeCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string DiscountTypeCode { get; set; }

        public decimal DiscountAmount { get; set; }
        
        public decimal ActualPrice { get; set; }
        public Company? Company { get; set; }

        public ServiceType? ServiceType { get; set; }
        public Discount? Discount { get; set; }

        public List<ServiceTime> ServiceTimes { get; set; }
        public List<Appointment> Appointments { get; private set; }
    }
}
