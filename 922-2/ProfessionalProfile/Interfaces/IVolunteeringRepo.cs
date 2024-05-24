using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Interfaces
{
    public interface IVolunteeringRepo
    {
        public Volunteering GetById(int id);
        public ICollection<Volunteering> GetAll();
        public void Add(Volunteering item);
        public void Update(Volunteering item);
        public void Delete(int id);
    }
}
