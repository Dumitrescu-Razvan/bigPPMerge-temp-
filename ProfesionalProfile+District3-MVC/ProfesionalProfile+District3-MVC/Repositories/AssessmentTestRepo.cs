using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class AssessmentTestRepo : IAssessmentTestRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public AssessmentTestRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(AssessmentTest item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.AssessmentTests.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var assessmentTestsId = context.AssessmentTests.Find(id);
                context.AssessmentTests.Remove(assessmentTestsId);
                context.SaveChanges();
            }
        }

        public List<AssessmentTest> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.AssessmentTests.ToList();
            }
        }

        public AssessmentTest GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.AssessmentTests.Find(id);
            }
        }

        public void Update(AssessmentTest assessmentTests)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.AssessmentTests.Update(assessmentTests);
                context.SaveChanges();
            }
        }
        public int GetIdByName(string testName)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.AssessmentTests.Where(x => x.testName == testName).Select(x => x.assessmentTestId).FirstOrDefault();
            }
        } 

        public List<Question> GetQuestions(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Questions.Where(x => x.assesmentTestId == id).ToList();
            }
        }

        public List<Answer> GetAnswers(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Answers.Where(x => x.questionId == id).ToList();
            }
        }
    }
}