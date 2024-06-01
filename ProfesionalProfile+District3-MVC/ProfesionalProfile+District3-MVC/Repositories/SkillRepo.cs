using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class SkillRepo : ISkillRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public SkillRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Skill item)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Skills.Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var item = context.Skills.Find(id);
                    context.Skills.Remove(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<Skill> GetAll()
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.Skills.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Skill GetById(int id)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.Skills.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Skill> GetByUserId(int userId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetIdByName(string name)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.Skills.Where(x => x.name == name).FirstOrDefault().skillId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Skill item)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Skills.Update(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
