using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Interfaces
{
    public interface IAnswerRepo
    {
        public Answer GetById(int id);
        public ICollection<Answer> GetAll();
        public void Add(Answer item);
        public void Update(Answer item);
        public void Delete(int id);
        ICollection<Answer> GetAnswers(int questionId);
    }
}
