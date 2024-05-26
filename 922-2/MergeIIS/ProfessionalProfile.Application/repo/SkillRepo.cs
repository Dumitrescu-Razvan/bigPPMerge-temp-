using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class SkillRepo : ISkillRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public SkillRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Skill item)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Skill.Add(item);
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
                    var item = context.Skill.Find(id);
                    context.Skill.Remove(item);
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
                    return context.Skill.ToList();
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
                    return context.Skill.Find(id);
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
                    return context.Skill.Where(x => x.name == name).FirstOrDefault().skillId;
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
                    context.Skill.Update(item);
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
