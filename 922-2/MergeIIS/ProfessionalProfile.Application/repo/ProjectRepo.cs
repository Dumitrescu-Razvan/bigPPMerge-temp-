using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public ProjectRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Project item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Project.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var project = context.Project.Find(id);
                context.Project.Remove(project);
                context.SaveChanges();
            }
        }

        public ICollection<Project> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Project.ToList();
            }
        }

        public Project GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Project.Find(id);
            }
        }

        public void Update(Project project)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Project.Update(project);
                context.SaveChanges();
            }
        }
    }
}