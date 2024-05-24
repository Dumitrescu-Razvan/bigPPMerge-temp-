using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class EducationRepo : IEducationRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public EducationRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Education item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Education.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var education = context.Education.Find(id);
                context.Education.Remove(education);
                context.SaveChanges();
            }
        }

        public ICollection<Education> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Education.ToList();
            }
        }

        public Education GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Education.Find(id);
            }
        }

        public void Update(Education education)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Education.Update(education);
                context.SaveChanges();
            }
        }
    }
}