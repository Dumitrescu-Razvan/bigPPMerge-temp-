using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Interfaces
{
    public interface IEducationRepo
    {
        public Education GetById(int id);
        public ICollection<Education> GetAll();
        public void Add(Education item);
        public void Update(Education item);
        public void Delete(int id);
    }
}
