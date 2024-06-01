using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
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
