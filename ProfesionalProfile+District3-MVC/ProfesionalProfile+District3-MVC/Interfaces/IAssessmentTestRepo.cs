using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IAssessmentTestRepo
    {
        public AssessmentTest GetById(int id);
        public ICollection<AssessmentTest> GetAll();
        public void Add(AssessmentTest item);
        public void Update(AssessmentTest item);
        public void Delete(int id);
        public int GetIdByName(string testName);

        public List<Question> GetQuestions(int id);
    }
}
