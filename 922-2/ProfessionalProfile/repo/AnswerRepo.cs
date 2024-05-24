using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Interfaces;

namespace ProfessionalProfile.repo
{
    public class AnswerRepo : IAnswerRepo
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        public AnswerRepo(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Add(Answer item)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Answers.Add(item);
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
                    var answer = context.Answers.Find(id);
                    context.Answers.Remove(answer);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<Answer> GetAll()
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.Answers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Answer GetById(int id)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.Answers.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Answer answer)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Answers.Update(answer);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<Answer> GetAnswers(int QuestionId)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return context.Answers.Where(x => x.questionId == QuestionId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
