using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Authentication.Queries
{
    public record LoginQuery : IRequest<LoginQueryResult>
    {
        public string username;
        public string password;
    }
}
