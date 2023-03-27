using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Company;

namespace VehicleAssist.Domain.Service
{
    public class Discount : BaseEntity
    {
        public string DiscountTypeCode   { get; set; }
        public int Description { get; set; }
        public List<CompanyService> CompanyServices { get; set; }
    }
}
