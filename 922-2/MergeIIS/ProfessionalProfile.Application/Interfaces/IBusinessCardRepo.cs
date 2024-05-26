using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Interfaces
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
