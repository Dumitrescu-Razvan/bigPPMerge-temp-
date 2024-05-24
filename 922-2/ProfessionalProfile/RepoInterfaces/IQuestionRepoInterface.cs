using ProfessionalProfile.Repo;

namespace ProfessionalProfile.RepoInterfaces
{
    public interface IQuestionRepoInterface<T> : IRepoInterface<T>
    {
        public int GetIdByNameAndAssessmentId(string questionName, int assessmentId);
        public List<T> GetAllByTestId(int testId);
    }
}
