using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public QuestionRepo(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Question item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Questions.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var question = context.Questions.Find(id);
                context.Questions.Remove(question);
                context.SaveChanges();
            }
        }

        public ICollection<Question> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Questions.ToList();
            }
        }

        public Question GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Questions.Find(id);
            }
        }

        public void Update(Question question)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Questions.Update(question);
                context.SaveChanges();
            }
        }
        //Interface member 'List<Question> ProfesionalProfile_District3_MVC.Interfaces.IQuestionRepo.GetAllByTestId(int)' is not implemented
        //Interface member 'int ProfesionalProfile_District3_MVC.Interfaces.IQuestionRepo.GetIdByNameAndAssessmentId(string, int)' is not implemented
        public List<Question> GetAllByTestId(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Questions.Where(x => x.assesmentTestId == id).ToList();
            }
        }
        
        public int GetIdByNameAndAssessmentId(string question, int assessmentId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Questions.Where(x => x.questionText == question && x.assesmentTestId == assessmentId).Select(x => x.questionId).FirstOrDefault();
            }
        }
    }
}