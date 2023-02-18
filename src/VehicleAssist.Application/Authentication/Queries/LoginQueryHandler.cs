using MediatR;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Authentication.Queries
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResult>
    {

        ITokenGenerator _tokenGenerator;
        IMemberRepository _memberRepository;
     


        public LoginQueryHandler(ITokenGenerator tokenGenerator, IMemberRepository memberRepository) { 
            _tokenGenerator = tokenGenerator;
            _memberRepository = memberRepository;
           

        }

        public async Task<LoginQueryResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            //Find if email exists
            Member member = _memberRepository.GetMemberByEmail(request.email);



            if(member == null)
            {
                //throw exception ?
                throw new ArgumentException("Email Doesn't Exist");
            }


            if (request.email == request.password)
            {


                LoginQueryResult result = new LoginQueryResult()
                {
                    userId = member.MemberID,
                    token = _tokenGenerator.GenerateToken(member.MemberID, member.FirstName, member.Email)

                };

               
                return result;

            }
            else
            {
                throw new Exception("Wrong auth!");
            }

        }
    }
}
