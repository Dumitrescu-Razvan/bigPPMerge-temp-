using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.RepoInterfaces
{
    public interface IAssessmentTestRepoInterface<T> : IRepoInterface<T>
    {
        public int GetIdByName(string testName);
    }
}
