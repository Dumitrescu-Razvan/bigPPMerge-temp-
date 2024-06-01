using ProfesionalProfile_District3_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IUserRepo
    {
        public User GetById(int id);
        public ICollection<User> GetAll();
        public void Add(User item);
        public void Update(User item);
        public void Delete(int id);
    }
}
