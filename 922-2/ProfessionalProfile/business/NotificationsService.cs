using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Business
{
    public class NotificationsService
    {
        public INotificationRepoInterface<Notification> NotificationRepo { get; }

        public NotificationsService(INotificationRepoInterface<Notification> notificationRepo)
        {
            this.NotificationRepo = notificationRepo;
        }

        public List<Notification> GetNotifications(int userId)
        {
            List<Notification> notifications = this.NotificationRepo.GetAllByUserId(userId);

            notifications.Sort((firstNotification, secondNotification) =>
            {
                return secondNotification.Timestamp.CompareTo(firstNotification.Timestamp);
            });

            return notifications;
        }

        public void AddNotification(Notification notification)
        {
            NotificationRepo.Add(notification);
        }
    }
}
