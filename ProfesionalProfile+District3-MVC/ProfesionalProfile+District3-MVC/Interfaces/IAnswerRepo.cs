using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Repositories;

namespace ProfesionalProfile_District3_MVC.Interfaces
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
