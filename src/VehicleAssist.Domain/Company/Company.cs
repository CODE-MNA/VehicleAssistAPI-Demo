using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Company
{
    public class Company : Member.Member
    {
        public string CompanyName { get; set; }

        public string? CompanyDescription { get; set; }
    }
}
