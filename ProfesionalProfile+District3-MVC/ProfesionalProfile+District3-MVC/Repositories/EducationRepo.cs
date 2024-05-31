using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class EducationRepo : IEducationRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public EducationRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Education item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Educations.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var education = context.Educations.Find(id);
                context.Educations.Remove(education);
                context.SaveChanges();
            }
        }

        public ICollection<Education> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Educations.ToList();
            }
        }

        public Education GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Educations.Find(id);
            }
        }

        public void Update(Education education)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Educations.Update(education);
                context.SaveChanges();
            }
        }
    }
}