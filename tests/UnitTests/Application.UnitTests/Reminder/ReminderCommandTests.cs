using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer;
using VehicleAssist.Application.Customer.Commands;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Reminders;
using Xunit;

namespace Application.UnitTests.Reminder
{
    public class ReminderCommandTests
    {
        Mock<ICustomerRepository> _vehicleOwnerRepository;
        Mock<IBaseRepository<VehicleAssist.Domain.Reminders.Reminder>> _reminderRepository;
        Mock<IPublisher> _publisher;
        Mock<IUnitOfWork> _unitOfWork;
        Mock<INotificationRepository> _notificationRepository;


        public ReminderCommandTests()
        {
            _vehicleOwnerRepository = new();
            _unitOfWork = new();
            _reminderRepository = new();
            _publisher = new();
            _notificationRepository = new();
        }


        [Fact]
        public async Task Verify_AddReminderInformationHandler_Success()
        {

            //arrange
            var addReminderCommand = new AddReminderForCustomerCommand() { Name = "Reminder Change oil", CustomerId = 1, Description = "Test Reminder", ReminderDateTime = new DateTimeOffset(2023, 5, 1, 10, 30, 0, TimeSpan.FromHours(2)), ServiceType = "CHNGO", Latitude = 44.2f, Longitude = 94.9f, ReminderSchedules = new List<ReminderScheduleDTO>() { new ReminderScheduleDTO(12.2f,"Hours"), new ReminderScheduleDTO(12.2f, "Hours") }
            };


            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder(addReminderCommand.Name, addReminderCommand.Description, addReminderCommand.ReminderDateTime, addReminderCommand.ServiceType, addReminderCommand.Latitude, addReminderCommand.Longitude)
            {

            };

            _vehicleOwnerRepository.Setup(x => x.AddReminderToCustomer(1, reminder));


            var handler = new AddReminderForCustomerCommandHandler(_vehicleOwnerRepository.Object, _unitOfWork.Object, _publisher.Object);

            //Act
            var result = await handler.Handle(addReminderCommand, default);


            //Assert
            _unitOfWork.Verify(x => x.CommitChanges(), Times.Once);

        }


        [Fact]
        public async Task Verify_UpdateReminderInformationHandler_Success()
        {
            //Arrange 
            var updateReminderCommand = new UpdateReminderCommand()
            {
                Name = "Reminder Change oil",
                CustomerId = 1,
                Description = "Test Reminder",
                ReminderDateTime = new DateTimeOffset(2023, 5, 1, 10, 30, 0, TimeSpan.FromHours(2)),
                ServiceType = "CHNGO",
                Latitude = 44.2f,
                Longitude = 94.9f,
                ReminderSchedules = new List<ReminderScheduleDTO>() { new ReminderScheduleDTO(12.2f, "Hours"), new ReminderScheduleDTO(12.2f, "Hours") }
            };


            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder(updateReminderCommand.Name, updateReminderCommand.Description, updateReminderCommand.ReminderDateTime, updateReminderCommand.ServiceType, updateReminderCommand.Latitude, updateReminderCommand.Longitude)
            {

            };

            _reminderRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns(reminder);

            var handler = new UpdateReminderCommandHandler(_reminderRepository.Object, _unitOfWork.Object, _publisher.Object, _notificationRepository.Object);


            //Act
            var result = await handler.Handle(updateReminderCommand, default);


            _unitOfWork.Verify(x => x.CommitChanges(), Times.Once);
        }

        [Fact]
        public async Task Verify_DeleteReminderInformationHandler_Success()
        {
            //Arrange
            var reminderDeleteCommand = new DeleteReminderCommand() { CustomerId = 0, ReminderId = 1 };
            
            var updateReminderCommand = new UpdateReminderCommand()
            {
                Name = "Reminder Change oil",
                CustomerId =0,
                Description = "Test Reminder",
                ReminderDateTime = new DateTimeOffset(2023, 5, 1, 10, 30, 0, TimeSpan.FromHours(2)),
                ServiceType = "CHNGO",
                Latitude = 44.2f,
                Longitude = 94.9f,
                ReminderSchedules = new List<ReminderScheduleDTO>() { new ReminderScheduleDTO(12.2f, "Hours"), new ReminderScheduleDTO(12.2f, "Hours") }
            };

            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder("Reminder Change oil", "test description", new DateTime(2023 - 06 - 05), "CHNGO", 44.2f, 94.9f)
            {

            };


            _reminderRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns(reminder);

            var handler = new DeleteReminderCommandHandler(_reminderRepository.Object, _unitOfWork.Object, _notificationRepository.Object,_publisher.Object);


            //Act
            var result = await handler.Handle(reminderDeleteCommand, default);

            //assert
            _unitOfWork.Verify(x => x.CommitChanges(), Times.Once);
        }

        [Fact]
        public async Task Verify_QueryReminderInformationHandler_Success()
        {
            //Arrange
            var queryReminderCommand = new ReminderDetailsQuery() { CustomerId = 0, ReminderId = 0 };

            var updateReminderCommand = new UpdateReminderCommand()
            {
                Name = "Reminder Change oil",
                CustomerId = 0,
                Description = "Test Reminder",
                ReminderDateTime = new DateTimeOffset(2023, 5, 1, 10, 30, 0, TimeSpan.FromHours(2)),
                ServiceType = "CHNGO",
                Latitude = 44.2f,
                Longitude = 94.9f,
                ReminderSchedules = new List<ReminderScheduleDTO>() { new ReminderScheduleDTO(12.2f, "Hours"), new ReminderScheduleDTO(12.2f, "Hours") }
            };


            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder(updateReminderCommand.Name, updateReminderCommand.Description, updateReminderCommand.ReminderDateTime, updateReminderCommand.ServiceType, updateReminderCommand.Latitude, updateReminderCommand.Longitude)
            {
                ReminderAlarmSchedules = new List<ReminderAlarmSchedule>() { }
            };



            _reminderRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns(reminder);


            var handler = new ReminderDetailsQueryHandler(_reminderRepository.Object);


            //Act
            CancellationToken cancellationToken = new CancellationToken();
            var result = await handler.Handle(queryReminderCommand, cancellationToken);

            ReminderDTO expectedReminder = new ReminderDTO(0, "Reminder Change oil", "Test Reminder", new DateTime(2023, 5, 1, 10, 30, 0), "CHNGO", 44.2f, 94.9f);


            //Assert
            Assert.Equal(expectedReminder.ReminderId, result.ReminderId);
            Assert.Equal(expectedReminder.Name, result.Name);
            Assert.Equal(expectedReminder.ServiceType, result.ServiceType);
            Assert.Equal(expectedReminder.Description, result.Description);
        }

        [Fact]
        public async Task Verify_ValidationOfFailedUpdateReminderInformation_Success()
        {
            //Arrange 
            var updateReminderCommand = new UpdateReminderCommand()
            {
                Name = "Reminder Change oil",
                CustomerId = 0,
                Description = "Test Reminder",
                ReminderDateTime = new DateTimeOffset(2023, 5, 1, 10, 30, 0, TimeSpan.FromHours(2)),
                ServiceType = "CHNGO",
                Latitude = 44.2f,
                Longitude = 94.9f,
                ReminderSchedules = new List<ReminderScheduleDTO>() { new ReminderScheduleDTO(12.2f, "Hours"), new ReminderScheduleDTO(12.2f, "Hours") }
            };


            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder(updateReminderCommand.Name, updateReminderCommand.Description, updateReminderCommand.ReminderDateTime, updateReminderCommand.ServiceType, updateReminderCommand.Latitude, updateReminderCommand.Longitude)
            {
                ReminderAlarmSchedules = new List<ReminderAlarmSchedule>() { }
            };

            _reminderRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns((VehicleAssist.Domain.Reminders.Reminder?)null);


            var handler = new UpdateReminderCommandHandler(_reminderRepository.Object, _unitOfWork.Object, _publisher.Object, _notificationRepository.Object);            
           

            //Act
            var ex = await Assert.ThrowsAsync<ReminderDoesntExistException>(() => handler.Handle(updateReminderCommand, default));

            string expected = "Can't Update reminder";

            //Assert
            Assert.Equal(expected, ex.Message);
            _unitOfWork.Verify(x => x.CommitChanges(), Times.Never);

        }

        [Fact]
        public async Task Verify_ValidateFailureToDeleteReminderIfReminderIdNotFound_Success()
        {
            //Arrange
            var reminderDeleteCommand = new DeleteReminderCommand() { CustomerId = 0, ReminderId = 1 };

            var updateReminderCommand = new UpdateReminderCommand()
            {
                Name = "Reminder Change oil",
                CustomerId = 0,
                Description = "Test Reminder",
                ReminderDateTime = new DateTimeOffset(2023, 5, 1, 10, 30, 0, TimeSpan.FromHours(2)),
                ServiceType = "CHNGO",
                Latitude = 44.2f,
                Longitude = 94.9f,
                ReminderSchedules = new List<ReminderScheduleDTO>() { new ReminderScheduleDTO(12.2f, "Hours"), new ReminderScheduleDTO(12.2f, "Hours") }
            };


            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder(updateReminderCommand.Name, updateReminderCommand.Description, updateReminderCommand.ReminderDateTime, updateReminderCommand.ServiceType, updateReminderCommand.Latitude, updateReminderCommand.Longitude)
            {
                ReminderAlarmSchedules = new List<ReminderAlarmSchedule>() { }
            };

            _reminderRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns((VehicleAssist.Domain.Reminders.Reminder?)null);

            var handler = new DeleteReminderCommandHandler(_reminderRepository.Object, _unitOfWork.Object, _notificationRepository.Object, _publisher.Object);


            //Act
            var ex = await Assert.ThrowsAsync<ReminderDoesntExistException>(() => handler.Handle(reminderDeleteCommand, default));

            string expected = "Reminder not found";

            //Assert
            Assert.Equal(expected, ex.Message);
            _unitOfWork.Verify(x => x.CommitChanges(), Times.Never);
        }

        [Fact]
        public async Task Verify_ValidateFailureToDeleteReminderIfCustomerIdIsMismatch_Success()
        {
            //Arrange
            var reminderDeleteCommand = new DeleteReminderCommand() { CustomerId = 0, ReminderId = 1 };

            var updateReminderCommand = new UpdateReminderCommand()
            {
                Name = "Reminder Change oil",
                CustomerId = 1,
                Description = "Test Reminder",
                ReminderDateTime = new DateTimeOffset(2023, 5, 1, 10, 30, 0, TimeSpan.FromHours(2)),
                ServiceType = "CHNGO",
                Latitude = 44.2f,
                Longitude = 94.9f,
                ReminderSchedules = new List<ReminderScheduleDTO>() { new ReminderScheduleDTO(12.2f, "Hours"), new ReminderScheduleDTO(12.2f, "Hours") }
            };


            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder(updateReminderCommand.Name, updateReminderCommand.Description, updateReminderCommand.ReminderDateTime, updateReminderCommand.ServiceType, updateReminderCommand.Latitude, updateReminderCommand.Longitude)
            {
                ReminderAlarmSchedules = new List<ReminderAlarmSchedule>() { }
            };
            reminder.CustomerId = 1;

            _reminderRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns(reminder);

            var handler = new DeleteReminderCommandHandler(_reminderRepository.Object, _unitOfWork.Object, _notificationRepository.Object, _publisher.Object);


            //Act
            var ex = await Assert.ThrowsAsync<CustomerDoesntExistException>(() => handler.Handle(reminderDeleteCommand, default));

            string expected = "Customer mismatch";

            //Assert
            Assert.Equal(expected, ex.Message);
            _unitOfWork.Verify(x => x.CommitChanges(), Times.Never);
        }
    }

}
