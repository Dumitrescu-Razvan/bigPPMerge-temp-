using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class WorkExperienceRepo : IWorkExperienceRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public WorkExperienceRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(WorkExperience item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.WorkExperience.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var workExperience = context.WorkExperience.Find(id);
                context.WorkExperience.Remove(workExperience);
                context.SaveChanges();
            }
        }

        public ICollection<WorkExperience> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.WorkExperience.ToList();
            }
        }

        public WorkExperience GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.WorkExperience.Find(id);
            }
        }

        public void Update(WorkExperience workExperience)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.WorkExperience.Update(workExperience);
                context.SaveChanges();
            }
        }
    }
}