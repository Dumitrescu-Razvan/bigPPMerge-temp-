using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Interfaces
{
    public interface ISkillRepo
    {
        public Skill GetById(int id);
        public ICollection<Skill> GetAll();
        public void Add(Skill item);
        public void Update(Skill item);
        public void Delete(int id);
        public List<Skill> GetByUserId(int userId);
        public int GetIdByName(string name);
    }
}
