using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Infrastructure.Email
{
    public class MailSettings
    {
        public string ConfigSectionName = "MailSettings";

       

        public string FromEmail { get; set; }

        public string FromPass { get; set; }

        public string VerifySecret { get; set; }

   
    }
}
