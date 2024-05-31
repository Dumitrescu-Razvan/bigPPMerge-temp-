using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IPrivacyRepo
    {
        public Privacy GetById(int id);
        public ICollection<Privacy> GetAll();
        public void Add(Privacy item);
        public void Update(Privacy item);
        public void Delete(int id);
    }
}
