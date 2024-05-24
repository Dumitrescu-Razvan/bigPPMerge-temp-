using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class BusinessCardRepo : IBusinessCardRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public BusinessCardRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(BusinessCard item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.BusinessCard.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var businessCard = context.BusinessCard.Find(id);
                context.BusinessCard.Remove(businessCard);
                context.SaveChanges();
            }
        }

        public ICollection<BusinessCard> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.BusinessCard.ToList();
            }
        }

        public BusinessCard GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.BusinessCard.Find(id);
            }
        }

        public void Update(BusinessCard businessCard)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.BusinessCard.Update(businessCard);
                context.SaveChanges();
            }
        }
    }
}