using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface INotificationRepo
    {
        public Notification GetById(int id);
        public ICollection<Notification> GetAll();
        public void Add(Notification item);
        public void Update(Notification item);
        public void Delete(int id);
        public List<Notification> GetAllByUserId(int userId);
    }
}
