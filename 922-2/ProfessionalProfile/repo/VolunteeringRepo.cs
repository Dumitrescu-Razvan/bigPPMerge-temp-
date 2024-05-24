using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class VolunteeringRepo : IVolunteeringRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public VolunteeringRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Volunteering item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Volunteering.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var volunteering = context.Volunteering.Find(id);
                context.Volunteering.Remove(volunteering);
                context.SaveChanges();
            }
        }

        public ICollection<Volunteering> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Volunteering.ToList();
            }
        }

        public Volunteering GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Volunteering.Find(id);
            }
        }

        public void Update(Volunteering volunteering)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Volunteering.Update(volunteering);
                context.SaveChanges();
            }
        }
    }
}