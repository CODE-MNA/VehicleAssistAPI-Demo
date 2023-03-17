using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Customer.Commands
{
    public class UpdateVehicleInformationCommand : IRequest<Unit>
    {
    }

    public class UpdateVehicleInformationCommandHandler : IRequestHandler<UpdateVehicleInformationCommand,Unit>
    {
      
        public Task<Unit> Handle(UpdateVehicleInformationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
