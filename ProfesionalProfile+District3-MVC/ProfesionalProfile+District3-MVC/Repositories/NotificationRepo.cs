using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public NotificationRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Notification item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Notifications.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var notification = context.Notifications.Find(id);
                context.Notifications.Remove(notification);
                context.SaveChanges();
            }
        }

        public ICollection<Notification> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Notifications.ToList();
            }
        }

        public Notification GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Notifications.Find(id);
            }
        }

        public void Update(Notification notification)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Notifications.Update(notification);
                context.SaveChanges();
            }
        }
        // List<Notification> ProfesionalProfile_District3_MVC.Interfaces.INotificationRepo.GetAllByUserId(int)' is not implemented
        public List<Notification> GetAllByUserId(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Notifications.Where(n => n.userId == id).ToList();
                
            }
        }
    }
}