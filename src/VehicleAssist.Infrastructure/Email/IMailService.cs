using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Infrastructure.Email
{
    public interface IMailService
    {
        public Task SendMailAsync(MailRequest mailRequest);


        
    }
}
