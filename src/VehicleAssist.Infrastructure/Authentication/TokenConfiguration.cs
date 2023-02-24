using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Infrastructure.Authentication
{
    public class TokenConfiguration
    {

        public  string ConfigSectionName = "JWTSettings";

        //issuer, secret , audience

        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpiryMinutes { get; set; }
    }
}
