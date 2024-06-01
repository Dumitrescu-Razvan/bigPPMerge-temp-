using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class VolunteeringRepo : IVolunteeringRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public VolunteeringRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Volunteering item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Volunteerings.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var volunteering = context.Volunteerings.Find(id);
                context.Volunteerings.Remove(volunteering);
                context.SaveChanges();
            }
        }

        public ICollection<Volunteering> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Volunteerings.ToList();
            }
        }

        public Volunteering GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Volunteerings.Find(id);
            }
        }

        public void Update(Volunteering volunteering)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Volunteerings.Update(volunteering);
                context.SaveChanges();
            }
        }
    }
}