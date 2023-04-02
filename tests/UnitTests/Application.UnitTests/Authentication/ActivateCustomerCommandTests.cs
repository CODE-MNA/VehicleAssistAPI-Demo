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
    public class ActivateCustomerCommandTests
    {

        Mock<IVerificationEmail> _verificationInterface;
        Mock<IMemberRepository> _memberRepository;
        Mock<IUnitOfWork> _unitOfWork;

        string randomToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.zDIERqryIwOAWUVsN5nOMn-3_5OgOOXNENoeUOmHTNY";

        public ActivateCustomerCommandTests()
        {
            _verificationInterface = new();
            _memberRepository = new();
            _unitOfWork = new();
        }


        [Fact]
        public async Task Handle_ShouldCallCommit_WhenValidTokenAndMemberFound()
        {
            //Arrange 
            var command = new ActivateCustomerCommand() { Token = randomToken };

            Mock<Member> mockMember = new Mock<Member>();



            _verificationInterface.Setup(m => m.VerifyActivationToken(It.IsAny<string>())).Returns(It.IsAny<int>()); // valid token setup
            _memberRepository.Setup(
                m => m.GetById(It.IsAny<int>()))
                .Returns(mockMember.Object); // member found setup
            
            
            
            var handler = new ActivateCustomerHandler(_verificationInterface.Object,_memberRepository.Object,_unitOfWork.Object);

            //Act
            var result = await handler.Handle(command,default);


            //Assert
            _unitOfWork.Verify(x=>x.CommitChanges(),Times.Once);
            
        }

        [Fact]

        public async Task Handle_ShouldNotCallCommit_WhenMemberNotFound()
        {
            //Arrange 
            var command = new ActivateCustomerCommand() { Token = randomToken };

            _memberRepository
                .Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((Member?)null); // member not found setup

            var handler = new ActivateCustomerHandler(_verificationInterface.Object, _memberRepository.Object, _unitOfWork.Object);

            //Act
            var ex =await  Assert.ThrowsAsync<Exception>(()=>handler.Handle(command, default));


            //Assert
            string expected = "Something went wrong with the verification!";

            Assert.Equal(expected, ex.Message);
            _unitOfWork.Verify(x => x.CommitChanges(), Times.Never);
        }

      

        [Fact]
        public async Task Handle_ShouldCallActivateUser_WhenValidTokenAndMemberFound()
        {
            //Arrange 
            var command = new ActivateCustomerCommand() { Token = randomToken };

            

            Mock<Member> mockMember = new Mock<Member>();
    

            _verificationInterface.Setup(m => m.VerifyActivationToken(It.IsAny<string>())).Returns(It.IsAny<int>()); // valid token setup
            _memberRepository.Setup(
                m => m.GetById(It.IsAny<int>()))
                .Returns(mockMember.Object); // member found setup



            var handler = new ActivateCustomerHandler(_verificationInterface.Object, _memberRepository.Object, _unitOfWork.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
          //  mockMember.Verify(m => m.ActivateUser(), Times.Once); 
      
        Assert.Equal(mockMember.Object.UserActivated,true);
        }

      
    }
}