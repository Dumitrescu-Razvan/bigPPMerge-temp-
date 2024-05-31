using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class PrivacyRepo : IPrivacyRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public PrivacyRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Privacy item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Privacies.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var privacy = context.Privacies.Find(id);
                context.Privacies.Remove(privacy);
                context.SaveChanges();
            }
        }

        public ICollection<Privacy> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Privacies.ToList();
            }
        }

        public Privacy GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Privacies.Find(id);
            }
        }

        public void Update(Privacy privacy)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Privacies.Update(privacy);
                context.SaveChanges();
            }
        }
    }
}