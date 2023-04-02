using Moq;
using System;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Commands;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Member;
using Xunit;

namespace Application.UnitTests.Authentication
{
    public class RegisterMemberCommandTests
    {

        Mock<IVerificationEmail> _verificationInterface;
        Mock<IMemberRepository> _memberRepository;
        Mock<IUnitOfWork> _unitOfWork;

        Mock<IPasswordHasher> _passwordHasher;
        

        string randomToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.zDIERqryIwOAWUVsN5nOMn-3_5OgOOXNENoeUOmHTNY";

        public RegisterMemberCommandTests()
        {
            _verificationInterface = new();
            _memberRepository = new();
            _unitOfWork = new();
            _passwordHasher = new();
        }

        [Fact]
        public async Task Handle_ShouldRegisterCustomer_WhenCompanyInformationNotProvided_WhenValidDataProvided(){


            //Arrange
             RegisterCommand command = new RegisterCommand(){
                    IsCompany = false,
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Email = "TestEmail@gmail.com",
                    PhoneNumber = "1232451245",
                    Password = "Test@1234",
                    ConfirmPassword = "Test@1234"
                    
             };
           
              RegisterCustomerCommandHandler handler = new RegisterCustomerCommandHandler(_verificationInterface.Object,
              _memberRepository.Object,
              _unitOfWork.Object,_passwordHasher.Object);
          
              string expectedResult = "Registered Customer";
              
              //Act
              var result =  await handler.Handle(command,default);

              //Assert
                Assert.Equal(expectedResult,result.Message);
              

        }

        [Fact]
        public async Task Handle_ShouldRegisterCompany_WhenCompanyInformationProvided_WhenValidDataProvided(){


            //Arrange
             RegisterCommand command = new RegisterCommand(){
                    IsCompany = true,
                    CompanyDescription = "CompanyDesc",
                    CompanyName = "CompanyName",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Email = "TestEmail@gmail.com",
                    PhoneNumber = "1232451245",
                    Password = "Test@1234",
                    ConfirmPassword = "Test@1234"
                    
             };
           
              RegisterCustomerCommandHandler handler = new RegisterCustomerCommandHandler(_verificationInterface.Object,
              _memberRepository.Object,
              _unitOfWork.Object,_passwordHasher.Object);
          
              string expectedResult = "Registered Company";
              
              //Act
              var result =  await handler.Handle(command,default);

              //Assert
                Assert.Equal(expectedResult,result.Message);
              

        }

    }
}