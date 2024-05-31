using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public ProjectRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Project item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Projects.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var project = context.Projects.Find(id);
                context.Projects.Remove(project);
                context.SaveChanges();
            }
        }

        public ICollection<Project> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Projects.ToList();
            }
        }

        public Project GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Projects.Find(id);
            }
        }

        public void Update(Project project)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Projects.Update(project);
                context.SaveChanges();
            }
        }
    }
}