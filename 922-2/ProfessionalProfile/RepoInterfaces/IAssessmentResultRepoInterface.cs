using ProfessionalProfile.Repo;

namespace ProfessionalProfile.RepoInterfaces
{
    public interface IAssessmentResultRepoInterface<T> : IRepoInterface<T>
    {
        public List<T> GetAssessmentResultsByUserId(int userId);
    }
}
