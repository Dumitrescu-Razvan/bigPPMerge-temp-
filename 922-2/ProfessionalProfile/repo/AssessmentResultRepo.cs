using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class AssessmentResultRepo : IAssessmentResultRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public AssessmentResultRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(AssessmentResult item)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.AssessmentResult.Add(item);
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
                    var assessmentResult = context.AssessmentResult.Find(id);
                    context.AssessmentResult.Remove(assessmentResult);
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
                    return context.AssessmentResult.ToList();
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
                    return context.AssessmentResult.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(AssessmentResult assessmentResult)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.AssessmentResult.Update(assessmentResult);
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
                    return context.AssessmentResult.Where(x => x.userId == userId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
