using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class BusinessCardRepo : IBusinessCardRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public BusinessCardRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(BusinessCard item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.BusinessCards.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var businessCard = context.BusinessCards.Find(id);
                context.BusinessCards.Remove(businessCard);
                context.SaveChanges();
            }
        }

        public ICollection<BusinessCard> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.BusinessCards.ToList();
            }
        }

        public BusinessCard GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.BusinessCards.Find(id);
            }
        }

        public void Update(BusinessCard businessCard)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.BusinessCards.Update(businessCard);
                context.SaveChanges();
            }
        }
    }
}