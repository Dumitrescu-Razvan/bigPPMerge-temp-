using ProfessionalProfile.Repo;

namespace ProfessionalProfile.RepoInterfaces
{
    public interface IAnswerRepoInterface<T> : IRepoInterface<T>
    {
        List<T> GetAnswers(int questionId);
    }
}
