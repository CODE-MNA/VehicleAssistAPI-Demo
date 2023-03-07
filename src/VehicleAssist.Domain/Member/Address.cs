using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Member
{
    public class Address
    {
        public int AddressId { get; set; }
        string Street1 { get; set; }
        string? Street2 { get; set; }

         string City { get; set; }

        //Provice
        //Country
        
        string ZipCode { get; set; }
        
    }
}
