using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Interfaces
{
    public interface IQuestionRepo
    {
        public Question GetById(int id);
        public ICollection<Question> GetAll();
        public void Add(Question item);
        public void Update(Question item);
        public void Delete(int id);
        public int GetIdByNameAndAssessmentId(string questionName, int assessmentId);
        public List<Question> GetAllByTestId(int testId);
    }
}
