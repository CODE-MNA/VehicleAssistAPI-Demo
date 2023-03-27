using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Company
{
    public class Deal : BaseEntity
    {
        public int DealId { get; set; }

        public int MemberId { get; set; }

        public string DealName { get; set; }

        public string Content { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Company? Company { get; set; }

    }
}
