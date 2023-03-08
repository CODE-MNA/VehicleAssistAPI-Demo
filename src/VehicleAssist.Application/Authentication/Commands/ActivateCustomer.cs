using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Authentication.Commands
{
    public record ActivateCustomerCommand : IRequest<Unit>
    {
        public string Token { get; set; }
    }


    internal class ActivateCustomerHandler : IRequestHandler<ActivateCustomerCommand,Unit>
    {

        IVerificationEmail _verificationInterface;
        IMemberRepository _memberRepository;
        IUnitOfWork _unitOfWork;

        public ActivateCustomerHandler(IVerificationEmail verificationInterface, IMemberRepository memberRepository, IUnitOfWork unitOfWork)
        {
            _verificationInterface = verificationInterface;
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ActivateCustomerCommand request, CancellationToken cancellationToken)
        {

          int decodedUserId =  _verificationInterface.VerifyActivationToken(request.Token);

            
           Member? member = _memberRepository.GetById(decodedUserId);

            if(member == null)
            {
                throw new Exception("Something is Wrong with the verification");
            }


            member.ActivateUser();
            _unitOfWork.CommitChanges();

            return Unit.Value;
        }

      
    }

}
