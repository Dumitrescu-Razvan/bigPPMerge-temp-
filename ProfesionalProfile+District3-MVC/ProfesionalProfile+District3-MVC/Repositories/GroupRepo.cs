using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class GroupRepository : IRepoInterface<Group>
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Group item)
        {
            _context.Group.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var group = _context.Group.Find(id);
            if (group != null)
            {
                _context.Group.Remove(group);
                _context.SaveChanges();
            }
        }

        public ICollection<Group> GetAll()
        {
            return _context.Group.ToList();
        }

        public Group GetById(int id)
        {
            return _context.Group.Find(id);
        }

        public void Update(Group item)
        {
            _context.Group.Update(item);
            _context.SaveChanges();
        }
    }
}