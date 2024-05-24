using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public QuestionRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Question item)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Question.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var question = context.Question.Find(id);
                context.Question.Remove(question);
                context.SaveChanges();
            }
        }

        public ICollection<Question> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Question.ToList();
            }
        }

        public Question GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Question.Find(id);
            }
        }

        public void Update(Question question)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Question.Update(question);
                context.SaveChanges();
            }
        }
        //Interface member 'List<Question> ProfessionalProfile.Interfaces.IQuestionRepo.GetAllByTestId(int)' is not implemented
        //Interface member 'int ProfessionalProfile.Interfaces.IQuestionRepo.GetIdByNameAndAssessmentId(string, int)' is not implemented
        public List<Question> GetAllByTestId(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Question.Where(x => x.assesmentTestId == id).ToList();
            }
        }
        
        public int GetIdByNameAndAssessmentId(string question, int assessmentId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Question.Where(x => x.questionText == question && x.assesmentTestId == assessmentId).Select(x => x.questionId).FirstOrDefault();
            }
        }
    }
}