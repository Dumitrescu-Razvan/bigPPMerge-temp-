using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public NotificationRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Notification item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Notification.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var notification = context.Notification.Find(id);
                context.Notification.Remove(notification);
                context.SaveChanges();
            }
        }

        public ICollection<Notification> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Notification.ToList();
            }
        }

        public Notification GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Notification.Find(id);
            }
        }

        public void Update(Notification notification)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Notification.Update(notification);
                context.SaveChanges();
            }
        }
        // List<Notification> ProfessionalProfile.Interfaces.INotificationRepo.GetAllByUserId(int)' is not implemented
        public List<Notification> GetAllByUserId(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Notification.Where(n => n.userId == id).ToList();
                
            }
        }
    }
}