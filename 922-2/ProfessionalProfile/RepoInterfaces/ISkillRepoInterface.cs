using ProfessionalProfile.Repo;

namespace ProfessionalProfile.RepoInterfaces
{
    public interface ISkillRepoInterface<T> : IRepoInterface<T>
    {
        public new List<T> GetAll();
        public List<T> GetByUserId(int userId);
        public new T GetById(int id);
        public int GetIdByName(string name);
    }
}
