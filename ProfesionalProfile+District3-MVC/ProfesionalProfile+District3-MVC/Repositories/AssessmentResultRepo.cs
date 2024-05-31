using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class AssessmentResultRepo : IAssessmentResultRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public AssessmentResultRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(AssessmentResult item)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.AssessmentResults.Add(item);
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
                    var AssessmentResults = context.AssessmentResults.Find(id);
                    context.AssessmentResults.Remove(AssessmentResults);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<AssessmentResult> GetAll()
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.AssessmentResults.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AssessmentResult GetById(int id)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.AssessmentResults.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(AssessmentResult AssessmentResults)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.AssessmentResults.Update(AssessmentResults);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<AssessmentResult> GetAssessmentResultsByUserId(int userId)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.AssessmentResults.Where(x => x.userId == userId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
