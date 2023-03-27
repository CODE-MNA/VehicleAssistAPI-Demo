using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Authentication.Queries.Login
{
    public record LoginQuery : IRequest<LoginQueryResult>
    {
        public string userName;
        public string password;
    }
}
