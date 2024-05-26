using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class EndorsementRepo : IEndorsementRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public EndorsementRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Endorsement item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Endorsement.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var endorsement = context.Endorsement.Find(id);
                context.Endorsement.Remove(endorsement);
                context.SaveChanges();
            }
        }

        public ICollection<Endorsement> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Endorsement.ToList();
            }
        }

        public Endorsement GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Endorsement.Find(id);
            }
        }

        public void Update(Endorsement endorsement)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Endorsement.Update(endorsement);
                context.SaveChanges();
            }
        }
    }
}