using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
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
