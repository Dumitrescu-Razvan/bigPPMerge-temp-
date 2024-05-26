using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Interfaces
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
