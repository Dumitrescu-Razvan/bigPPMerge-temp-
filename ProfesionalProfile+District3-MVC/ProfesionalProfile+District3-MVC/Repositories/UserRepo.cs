using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    /*
    public class UserRepository : IRepoInterface<AutisticUser>
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(AutisticUser item)
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

        public ICollection<AutisticUser> GetAll()
        {
            return _context.User.ToList();
        }

        public AutisticUser GetById(int id)
        {
            return _context.User.Find(id);
        }

        public void Update(AutisticUser item)
        {
            _context.User.Update(item);
            _context.SaveChanges();
        }
    }*/
}