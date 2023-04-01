using MediatR;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Commands;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Application.Customer;
using VehicleAssist.Application.Customer.Commands;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Member;
using Xunit;

namespace Application.UnitTests.Vehicle
{
    public class VehicleCommandTests
    {
        Mock<ICustomerRepository> _vehicleOwnerRepository;
        Mock<IBaseRepository<VehicleAssist.Domain.Customer.Vehicle>> _vehicleRepository;
        Mock<IUnitOfWork> _unitOfWork;
        Mock<IMediator> _mediator;

        public VehicleCommandTests()
        {
            _vehicleOwnerRepository = new();
            _unitOfWork = new();
            _vehicleRepository= new();
            _mediator = new();
        }

        [Fact]
        public async Task Verify_AddVehicleInformationHandler_Success()
        {
            //Arrange 
            var command = new AddVehicleToCustomerCommand() { Name = "VehicleXYZ", PlateNumber = "CSQW 232", Description = "SUV Car with customize mugs", Color = "Red", Mileage = 85090, ImageData = "testimage", CustomerId = 1 };

            VehicleAssist.Domain.Customer.Vehicle vehicle = VehicleAssist.Domain.Customer.Vehicle.CreateVehicleFromInput(command.Name, command.PlateNumber, command.Description, command.Color, command.Mileage, command.ImageData, command.CustomerId);
            _vehicleOwnerRepository.Setup(x => x.AddVehicleToCustomer(1, vehicle));

            var handler = new AddVehicleToCustomerHandler(_vehicleOwnerRepository.Object, _unitOfWork.Object);

            //Act
            var result = await handler.Handle(command, default);


            //Assert
            _unitOfWork.Verify(x => x.CommitChanges(), Times.Once);
        }

        [Fact]
        public async Task Verify_UpdateVehicleInformationHandler_Success()
        {
            //Arrange 
            var updateCommand = new UpdateVehicleInformationCommand() { VehicleId = 1, Name = "VehicleXYZ", PlateNumber = "CSQW 232", Description = "SUV Car with customize mugs", Color = "Red", Mileage = 85090, CustomerId=1, ImageLink = "TestImage" };
            VehicleAssist.Domain.Customer.Vehicle updateVehicle = new VehicleAssist.Domain.Customer.Vehicle(1, "TestVehicleABD", "CSQW 232", "SUV Card Desc", "Red", 20000, "testImageA", 1);
            _vehicleRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns(updateVehicle);
            var handler = new UpdateVehicleInformationCommandHandler(_vehicleRepository.Object, _unitOfWork.Object);


            //Act
            var result = await handler.Handle(updateCommand, default);


            _unitOfWork.Verify(x => x.CommitChanges(), Times.Once);                                                                                                                   
        }

        [Fact]
        public async Task Verify_DeleteVehicleInformationHandler_Success()
        {
            //Arrange
            var vehicleDeleteCommand = new DeleteVehicleCommand() { CustomerId = 1, VehicleId= 1 };
            VehicleAssist.Domain.Customer.Vehicle updateVehicle = new VehicleAssist.Domain.Customer.Vehicle(1, "TestVehicleABD", "CSQW 232", "SUV Card Desc", "Red", 20000, "testImageA", 1);
            _vehicleRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns(updateVehicle);
            var handler = new DeleteVehicleCommandHandler(_vehicleRepository.Object, _unitOfWork.Object);


            //Act
            var result = await handler.Handle(vehicleDeleteCommand, default);

            //assert
            _unitOfWork.Verify(x => x.CommitChanges(), Times.Once);
        }


        [Fact]
        public async Task Verify_QueryVehicleDetailsByID_Success()
        {

            //Arrange
            var queryVehicleCommand = new VehicleDetailsQuery() { CustomerId = 1, VehicleId = 1 };

            VehicleAssist.Domain.Customer.Vehicle updateVehicle = new VehicleAssist.Domain.Customer.Vehicle(1, "TestVehicleABD", "CSQW 232", "SUV Card Desc", "Red", 20000, "testImageA", 1);
            _vehicleRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns(updateVehicle);
            var handler = new VehicleDetailsQueryHandler(_vehicleRepository.Object);


            //Act
            CancellationToken cancellationToken = new CancellationToken();
            var result = await handler.Handle(queryVehicleCommand, cancellationToken);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Verify_FailedUpdateVehicleInformation_Success()
        {
            //Arrange 
            var updateCommand = new UpdateVehicleInformationCommand() { VehicleId = 1, Name = "VehicleXYZ", PlateNumber = "CSQW 232", Description = "SUV Car with customize mugs", Color = "Red", Mileage = 85090, CustomerId = 1, ImageLink = "TestImage" };
            VehicleAssist.Domain.Customer.Vehicle updateVehicle = new VehicleAssist.Domain.Customer.Vehicle(1, "TestVehicleABD", "CSQW 232", "SUV Card Desc", "Red", 20000, "testImageA", 1);
            _vehicleRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns((VehicleAssist.Domain.Customer.Vehicle?)null);

            var handler = new UpdateVehicleInformationCommandHandler(_vehicleRepository.Object, _unitOfWork.Object);
            

            _unitOfWork.Verify(x => x.CommitChanges(), Times.Never);
        }
    }
}
