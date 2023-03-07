﻿using MediatR;
using System.Reflection;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Authentication.Queries
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResult>
    {

        ITokenGenerator _tokenGenerator;
        IMemberRepository _memberRepository;
        IPasswordHasher _passwordHasher;


        public LoginQueryHandler(ITokenGenerator tokenGenerator, IMemberRepository memberRepository, IPasswordHasher hasher)
        {
            _tokenGenerator = tokenGenerator;
            _memberRepository = memberRepository;
            _passwordHasher = hasher;

        }

        public async Task<LoginQueryResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            //Find if username exists
            Member? member = _memberRepository.FindMemberByUsername(request.username);


            if (member == null)
            {
                //throw exception ?
                throw new LoginEmailNotFoundException("Username doesn't exist");
            }


            //ADD ROLES
            if (!member.UserActivated) throw new LoginUserNotActivatedException("User not activated");




            if (_passwordHasher.VerifyPassword(member.PasswordHash, request.password))
            {

                LoginQueryResult result = new LoginQueryResult()
                {
                    MemberId = member.MemberId,

                    Token = _tokenGenerator.GenerateToken(member),

                    FirstName = member.FirstName,

                    LastName = member.LastName,

                    Email = member.Email,

                    CellPhoneNumber = member.CellPhoneNumber,

                    MemberType = member.MemberType,
                };


                result.IsCompany = member.MemberType == "Company";
                return result;

            }
            else
            {
                throw new InvalidLoginCredentialsException("Wrong auth!");
            }

        }
    }
}
