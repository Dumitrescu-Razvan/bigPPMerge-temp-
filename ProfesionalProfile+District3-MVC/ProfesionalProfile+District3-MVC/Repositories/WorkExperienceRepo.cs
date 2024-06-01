using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class WorkExperienceRepo : IWorkExperienceRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public WorkExperienceRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(WorkExperience item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.WorkExperiences.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var workExperience = context.WorkExperiences.Find(id);
                context.WorkExperiences.Remove(workExperience);
                context.SaveChanges();
            }
        }

        public ICollection<WorkExperience> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.WorkExperiences.ToList();
            }
        }

        public WorkExperience GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.WorkExperiences.Find(id);
            }
        }

        public void Update(WorkExperience workExperience)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.WorkExperiences.Update(workExperience);
                context.SaveChanges();
            }
        }
    }
}