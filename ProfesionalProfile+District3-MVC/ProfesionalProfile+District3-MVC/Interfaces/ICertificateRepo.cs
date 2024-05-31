using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface ICertificateRepo
    {
        public Certificate GetById(int id);
        public ICollection<Certificate> GetAll();
        public void Add(Certificate item);
        public void Update(Certificate item);
        public void Delete(int id);
    }
}
