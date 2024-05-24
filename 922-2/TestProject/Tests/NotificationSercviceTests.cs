using Moq;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.MockedRepository;
using ProfessionalProfile.Interfaces;
using Xunit;

namespace TestProject
{
    public class NotificationSercviceTests
    {
        [Fact]
        public void GetNotifications_ReturnsNotifications()
        {

            // Arrange
            var notificationRepoMock = new NotificationRepositoryMock();
            var notificationsService = new NotificationsService(notificationRepoMock);

            var specificDateTime = new DateTime(2024, 4, 23, 10, 30, 0); // Year, Month, Day, Hour, Minute, Second
            Notification notificaton1 = new Notification(1, 1, "1", specificDateTime, "da", true);
            Notification notificaton2 = new Notification(2, 1, "1", specificDateTime, "da", true);
            Notification notificaton3 = new Notification(3, 1, "1", specificDateTime, "da", true);
            notificationsService.AddNotification(notificaton1);
            notificationsService.AddNotification(notificaton2);
            notificationsService.AddNotification(notificaton3);
            List<Notification> notifications = notificationsService.GetNotifications(1);

            // Act
            var result = notificationsService.GetNotifications(1);

            // Assert
            Assert.Equal(3, result.Count); 
            Assert.Equal(notifications[1].Timestamp, result[0].Timestamp); 
        }
        public void AddNotificationt_WorksAddingTheNotification()
        {
            // Arrange
            var notificationRepoMock = new NotificationRepositoryMock();
            var notificationsService = new NotificationsService(notificationRepoMock);

            var specificDateTime = new DateTime(2024, 4, 23, 10, 30, 0); // Year, Month, Day, Hour, Minute, Second
            Notification notificaton1 = new Notification(1, 1, "1", specificDateTime, "da", true);
            Notification notificaton2 = new Notification(2, 1, "1", specificDateTime, "da", true);
            Notification notificaton3 = new Notification(3, 1, "1", specificDateTime, "da", true);
            notificationsService.AddNotification(notificaton1 );
            notificationsService.AddNotification(notificaton2 );
            notificationsService.AddNotification(notificaton3 );
            List<Notification> notifications = notificationsService.GetNotifications(1);

            // Act
            var result = notificationsService.GetNotifications(1);

            // Assert
            Assert.Equal(3, result.Count); 
            Assert.Equal(notifications[1].Timestamp, result[0].Timestamp);
        }


    }
}
