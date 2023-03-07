using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Authentication.Commands
{

    /// <summary>
    /// Input DTO to the register handler 
    /// </summary>
    public record RegisterCustomerCommand : IRequest<RegisterCustomerCommandResult>
    {

        
  
        //TODO : validate to email/ phone number

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


      
    }


    /// <summary>
    /// Validate customer register input
    /// </summary>
    internal class ValidateRegisterCustomerCommand : AbstractValidator<RegisterCustomerCommand>
    {
        public ValidateRegisterCustomerCommand()
        {
            


           RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x=> x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();

            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);

        }
    }



    /// <summary>
    /// Checks if user already registered. If they aren't registers them to the database
    /// </summary>
    internal class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, RegisterCustomerCommandResult>
    {

        //Injection
        IMemberRepository _memberRepository;
        IUnitOfWork _unitOfWork;
        IPasswordHasher _passwordHasher;


        public RegisterCustomerCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork, IPasswordHasher hasher)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = hasher;
        }





        //Handle
        public async Task<RegisterCustomerCommandResult> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            




            //Check if Email already Exists
            Member? member = _memberRepository.FindMemberByEmail(request.Email);

            if(member != null)
            {
                throw new MemberAlreadyExistsException("Member already registered. Email already exists");
            }
         
            string hashedPassword = _passwordHasher.HashPassword(request.Password);

            Customer addingMember = Customer.CreateCustomerFromRegisterData(request.UserName,request.FirstName,request.LastName,request.Email,request.PhoneNumber,hashedPassword);

            _memberRepository.Add(addingMember);
            _unitOfWork.CommitChanges();


         
            return new RegisterCustomerCommandResult()
            {
           
               
            };
        }
    }

    /// <summary>
    /// Output from the handler
    /// </summary>
    public record RegisterCustomerCommandResult
    {
      

        

    }



} 
