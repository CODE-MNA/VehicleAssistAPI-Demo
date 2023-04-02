using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer;
using VehicleAssist.Application.Repositories;
using Xunit;
using VehicleAssist.Domain;
using VehicleAssist.Application.Customer.Queries;

namespace Application.UnitTests.Customer
{
    public class CalendarQueryTests
    {
        Mock<ICustomerRepository> _repository;

        public CalendarQueryTests()
        {
            _repository = new();
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyReminders_WhenNothingAdded()
        {
            //Arrange

            CalendarData data = new CalendarData();
            data.Reminders = new List<VehicleAssist.Domain.Reminders.Reminder>();
            data.Appointments = new List<VehicleAssist.Domain.Appointments.Appointment>();
           
            _repository.Setup(r => r.GetCalenderData(It.IsAny<int>()))
                .Returns(data);


            var query = new GetCalendarDataFromCustomer();

            var handler = new GetCalendarDataFromCustomerQueryHandler(_repository.Object);

            //Act 
            var result = await handler.Handle(query, default);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Reminders);
            Assert.Empty(result.Reminders);    

       

        }

        [Fact]
        public async Task Handle_ShouldReturnOneDTO_WhenOneReminderQueried()
        {
            //Arrange

            CalendarData data = new CalendarData();
            data.Reminders = new List<VehicleAssist.Domain.Reminders.Reminder>();
            data.Appointments = new List<VehicleAssist.Domain.Appointments.Appointment>();





            const string Name = "Reminder Name";
            const string Description = "Reminder Description";
            DateTimeOffset offset = DateTimeOffset.UtcNow;

            const string ServiceType = "Oil Change";
            const int Latitude = 0;
            const int Longitude = 0;
            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder(
                Name,
                Description,
                offset,
                ServiceType,
                Latitude,
                Longitude);

            data.Reminders.Add(reminder);


            _repository.Setup(r => r.GetCalenderData(It.IsAny<int>()))
                .Returns(data);


            var query = new GetCalendarDataFromCustomer();

            var handler = new GetCalendarDataFromCustomerQueryHandler(_repository.Object);

            //Act 
            var result = await handler.Handle(query, default);

            //Assert
            Assert.Single(result.Reminders);



        }

        [Fact]
        public async Task Handle_VerifyDTOValues_ShouldMatchReminderEntity()
        {
            //Arrange

            CalendarData data = new CalendarData();
            data.Reminders = new List<VehicleAssist.Domain.Reminders.Reminder>();
            data.Appointments = new List<VehicleAssist.Domain.Appointments.Appointment>();




            const string Name = "Reminder Name";
            const string Description = "Reminder Description";
            DateTimeOffset offset = DateTimeOffset.UtcNow;

            const string ServiceType = "Oil Change";
            const int Latitude = 0;
            const int Longitude = 0;

            VehicleAssist.Domain.Reminders.Reminder reminder = new VehicleAssist.Domain.Reminders.Reminder(
                Name,
                Description,
                offset,
                ServiceType,
                Latitude,
                Longitude);
            
      


            data.Reminders.Add(reminder);

            _repository.Setup(r => r.GetCalenderData(It.IsAny<int>()))
                .Returns(data);


            var query = new GetCalendarDataFromCustomer();

            var handler = new GetCalendarDataFromCustomerQueryHandler(_repository.Object);

            //Act 
            var result = await handler.Handle(query, default);

            //Assert
            Assert.Equal(Name,result.Reminders[0].Name);
            Assert.Equal(Description,result.Reminders[0].Description);
            Assert.Equal(Latitude,result.Reminders[0].Latitude);
            Assert.Equal(Longitude,result.Reminders[0].Longitude);
            Assert.Equal(ServiceType,result.Reminders[0].ServiceType);
            Assert.Equal(offset.Ticks,result.Reminders[0].ReminderDateTime.Ticks);

        }


    }
}
