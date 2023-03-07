using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Authentication
{
    public record LoginQueryResult
    {
      
        public int MemberId { get; set; }

      
        public string Token { get; set; }

        

    
        public bool IsCompany { get; set; }

    }
}
