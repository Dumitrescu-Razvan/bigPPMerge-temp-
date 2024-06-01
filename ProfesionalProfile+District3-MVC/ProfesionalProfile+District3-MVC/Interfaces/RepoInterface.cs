using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IRepoInterface<T>
    {
        public T GetById(int id);
        public ICollection<T> GetAll();
        public void Add(T item);
        public void Update(T item);
        public void Delete(int id);
    }
}
