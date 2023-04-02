using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleAssist.Application.Customer.Queries;
using VehicleAssist.Application.Customer;
using VehicleAssist.Application.Repositories;
using Xunit;
using VehicleAssist.Domain.Notification;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Application.UnitTests.Customer
{
    public class NotificationsForCustomerQueryHandlerTest
    {

        Mock<INotificationRepository> _notificationRepository;
        // Mock<IBaseRepository<VehicleAssist.Domain.Notification.Notification>> _notification;
        private readonly ITestOutputHelper output;

        public NotificationsForCustomerQueryHandlerTest(ITestOutputHelper output)
        {
            _notificationRepository = new();
            this.output = output;
        }

        [Fact]
        public async Task Handle_ShouldGetNotifications_WithCustomerId()
        {

            //Arrange
            var request = new NotificationsForCustomerRequest() { CustomerId = 1 };

            ICollection<Notification> notifications = new List<Notification>()
            {
                    new Notification() {
                        NotificationId = 1,
                        SendType = SendType.FinalReminder,
                        Content = "Mock data 1",
                        // UTC time format e.g 2023-04-02T00:34:03Z
                        TriggerTime = DateTime.UtcNow
                    },
                    new Notification() {
                        NotificationId = 2,
                        SendType = SendType.FinalReminder,
                        Content = "Mock data 2",
                        // UTC time format e.g 2023-04-02T00:34:03Z
                        TriggerTime = DateTime.UtcNow
                    }
            };

            _notificationRepository.Setup(n => n.GetNotificationsOfCustomer(It.IsAny<int>())).Returns(notifications);
            var handler = new NotificationsForCustomerQueryHandler(_notificationRepository.Object);
            CancellationToken cancellationToken = new CancellationToken();
            int expectedResultCount = 2;

            //Act
            NotificationsForCustomerResponse result = await handler.Handle(request, cancellationToken);

            //Assert
            Assert.Equal(expectedResultCount, result.Notifications.Count);

        }

        [Fact]
        public async Task Handle_ShouldGetUTCtimeforTriggerTime()
        {

            //Arrange
            var request = new NotificationsForCustomerRequest() { CustomerId = 1 };

            ICollection<Notification> notifications = new List<Notification>()
            {
                    new Notification() {
                        NotificationId = 1,
                        SendType = SendType.FinalReminder,
                        Content = "Mock data 1",
                        // UTC time format e.g 2023-04-02T00:34:03Z
                        TriggerTime = DateTime.UtcNow
                    },
                    new Notification() {
                        NotificationId = 2,
                        SendType = SendType.FinalReminder,
                        Content = "Mock data 2",
                        // UTC time format e.g 2023-04-02T00:34:03Z
                        TriggerTime = DateTime.UtcNow 
                    }
            };

            _notificationRepository.Setup(n => n.GetNotificationsOfCustomer(It.IsAny<int>())).Returns(notifications);
            var handler = new NotificationsForCustomerQueryHandler(_notificationRepository.Object);
            CancellationToken cancellationToken = new CancellationToken();

            //Act
            NotificationsForCustomerResponse result = await handler.Handle(request, cancellationToken);
            output.WriteLine("Acutall Result: {0}", result.Notifications.First().TriggerTime);

            //Assert
            Assert.Matches(@"\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}Z", result.Notifications.First().TriggerTime);

        }

    }
}
