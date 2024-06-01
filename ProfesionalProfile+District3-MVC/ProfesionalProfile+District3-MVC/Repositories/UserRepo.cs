using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class UserRepository : IRepoInterface<User>
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(User item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.User.Find(id);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
            }
        }

        public ICollection<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetById(int id)
        {
            return _context.User.Find(id);
        }

        public void Update(User item)
        {
            _context.User.Update(item);
            _context.SaveChanges();
        }
    }
}