using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IEndorsementRepo
    {
        public Endorsement GetById(int id);
        public ICollection<Endorsement> GetAll();
        public void Add(Endorsement item);
        public void Update(Endorsement item);
        public void Delete(int id);
    }
}
