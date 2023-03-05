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

    /// <summary>
    /// Input DTO to the register handler 
    /// </summary>
    public record RegisterCommand : IRequest<RegisterCommandResult>
    {
        public RegisterCommand(string name, string email, string phoneNumber, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        //TODO : Change data types to email/ phone number and validate them properly

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


        //TODO : Change to Validate Method which returns Validation Error
        public bool IsValid()
        {
            return AllValuesPopulated();
          
        }

        public bool AllValuesPopulated()
        {
            var collection = typeof(RegisterCommand).GetProperties();

            foreach (var item in collection)
            {
                if (string.IsNullOrEmpty(item.GetValue(this)?.ToString())) return false;
            }

            return true;
        }
    }







    /// <summary>
    /// Checks if user already registered. If they aren't registers them to the database
    /// </summary>
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
    {

        //Injection
        IMemberRepository _memberRepository;
        IUnitOfWork _unitOfWork;
        IPasswordHasher _passwordHasher;
        public RegisterCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork, IPasswordHasher hasher)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = hasher;
        }



        //Handle
        public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //Validate The Register Command Object

            if(!request.IsValid())
            {
                throw new ArgumentException("Request Not Valid");
            }




            //Check if Email already Exists
            Member member = _memberRepository.GetMemberByEmail(request.Email);

            if(member != null)
            {
                throw new Exception("Member already registered. Email already exists");
            }
            //TODO : Send Confirmation Email


            //TODO : Hash Password
            string hashedPassword = _passwordHasher.HashPassword(request.Password);

            Member addingMember = Member.CreateMemberFromRegisterData(request.Name,request.Name, request.Email, hashedPassword);

            _memberRepository.Add(addingMember);



         
            return new RegisterCommandResult()
            {
                Result = "Done",
                AllMembers= _memberRepository.GetList().ToList(),
                
            };
        }
    }

    /// <summary>
    /// Output from the handler
    /// </summary>
    public record RegisterCommandResult
    {
        public string Result { get; set; }

        //TEMP
        public List<Member> AllMembers { get; set; }

    }



} 
