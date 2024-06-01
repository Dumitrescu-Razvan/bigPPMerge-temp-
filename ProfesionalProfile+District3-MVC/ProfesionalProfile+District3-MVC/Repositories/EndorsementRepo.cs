using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class EndorsementRepo : IEndorsementRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public EndorsementRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Endorsement item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Endorsements.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var endorsement = context.Endorsements.Find(id);
                context.Endorsements.Remove(endorsement);
                context.SaveChanges();
            }
        }

        public ICollection<Endorsement> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Endorsements.ToList();
            }
        }

        public Endorsement GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Endorsements.Find(id);
            }
        }

        public void Update(Endorsement endorsement)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Endorsements.Update(endorsement);
                context.SaveChanges();
            }
        }
    }
}