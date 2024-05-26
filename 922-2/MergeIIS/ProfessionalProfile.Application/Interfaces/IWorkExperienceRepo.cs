using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Interfaces
{
    public interface IWorkExperienceRepo
    {
        public WorkExperience GetById(int id);
        public ICollection<WorkExperience> GetAll();
        public void Add(WorkExperience item);
        public void Update(WorkExperience item);
        public void Delete(int id);
    }
}
