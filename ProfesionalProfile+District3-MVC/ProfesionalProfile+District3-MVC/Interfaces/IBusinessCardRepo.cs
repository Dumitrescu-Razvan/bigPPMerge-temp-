using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IBusinessCardRepo
    {
        public BusinessCard GetById(int id);
        public ICollection<BusinessCard> GetAll();
        public void Add(BusinessCard item);
        public void Update(BusinessCard item);
        public void Delete(int id);
    }
}
