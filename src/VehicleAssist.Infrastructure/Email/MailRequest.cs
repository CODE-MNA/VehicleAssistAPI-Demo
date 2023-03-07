using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Infrastructure.Email
{
    public class MailRequest
    {
        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public string BodyRazorTemplate { get; set; }    

        public object Arguments { get; set; }
    }
}
