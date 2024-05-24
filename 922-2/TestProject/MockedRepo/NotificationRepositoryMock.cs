using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;
using ProfessionalProfile.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockedRepository
{
    public class NotificationRepositoryMock : INotificationRepoInterface<Notification>
    {
        List<Notification> notifications;
        public NotificationRepositoryMock() { 
            notifications = new List<Notification>();
        }

        public void Add(Notification notification)
        {
            notifications.Add(notification);
        } 

        public void Remove(Notification notification)
        {
            notifications.Remove(notification);
        }
        
        public List<Notification> GetAll()
        {
            return notifications;
        }

        public List<Notification> GetAllByUserId(int userId)
        {
            List<Notification> allNotifications = this.GetAll();

            return allNotifications.FindAll((notification) => notification.UserId == userId);
        }
        public void Delete(int id)
        {
        }
        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification item)
        {
        }
    }
}
