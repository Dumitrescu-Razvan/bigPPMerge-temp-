using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class AssessmentTestRepo : IAssessmentTestRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public AssessmentTestRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(AssessmentTest item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.AssessmentTest.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var assessmentTest = context.AssessmentTest.Find(id);
                context.AssessmentTest.Remove(assessmentTest);
                context.SaveChanges();
            }
        }

        public ICollection<AssessmentTest> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.AssessmentTest.ToList();
            }
        }

        public AssessmentTest GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.AssessmentTest.Find(id);
            }
        }

        public void Update(AssessmentTest assessmentTest)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.AssessmentTest.Update(assessmentTest);
                context.SaveChanges();
            }
        }
        public int GetIdByName(string testName)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.AssessmentTest.Where(x => x.testName == testName).Select(x => x.assessmentTestId).FirstOrDefault();
            }
        } 
    }
}