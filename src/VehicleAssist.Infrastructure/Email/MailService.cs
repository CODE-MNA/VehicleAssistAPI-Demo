using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentEmail;
using FluentEmail.Core;
using Microsoft.Extensions.Options;

namespace VehicleAssist.Infrastructure.Email
{
    public class MailService : IMailService
    {

        MailSettings _settings;
        IFluentEmail _fluentEmail;

        public MailService(IOptions<MailSettings> settings, IFluentEmail fluentEmail)
        {
            _settings = settings.Value;
            _fluentEmail = fluentEmail;
        }

        public Task SendMailAsync(MailRequest mailRequest)
        {



          return  _fluentEmail.To(mailRequest.ToEmail).Subject(mailRequest.Subject)
                .UsingTemplate(mailRequest.BodyRazorTemplate,mailRequest.Arguments).SendAsync();

        }
    }
}
