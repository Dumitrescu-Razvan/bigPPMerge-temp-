using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class PrivacyRepo : IPrivacyRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public PrivacyRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Privacy item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Privacy.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var privacy = context.Privacy.Find(id);
                context.Privacy.Remove(privacy);
                context.SaveChanges();
            }
        }

        public ICollection<Privacy> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Privacy.ToList();
            }
        }

        public Privacy GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Privacy.Find(id);
            }
        }

        public void Update(Privacy privacy)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Privacy.Update(privacy);
                context.SaveChanges();
            }
        }
    }
}