﻿using MediatR;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Authentication.Queries
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResult>
    {

        ITokenGenerator _tokenGenerator;
        IMemberRepository _memberRepository;
        IPasswordHasher _passwordHasher;


        public LoginQueryHandler(ITokenGenerator tokenGenerator, IMemberRepository memberRepository, IPasswordHasher hasher) { 
            _tokenGenerator = tokenGenerator;
            _memberRepository = memberRepository;
           _passwordHasher = hasher;

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

            //ADD ROLES
            if (!member.UserActivated) throw new ArgumentException("User not activated");




            if (_passwordHasher.VerifyPassword(member.PasswordHash,request.password))
            {


                LoginQueryResult result = new LoginQueryResult()
                {
                    userId = member.MemberID,
                    token = _tokenGenerator.GenerateToken(member)

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