using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class CloseFriendsProfileRepository : IRepoInterface<CloseFriendProfile>
    {
        private readonly ApplicationDbContext _context;
        public CloseFriendsProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CloseFriendProfile item)
        {
            _context.CloseFriendProfile.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var closeFriendProfile = _context.CloseFriendProfile.Find(id);
            if (closeFriendProfile != null)
            {
                _context.CloseFriendProfile.Remove(closeFriendProfile);
                _context.SaveChanges();
            }
        }

        public ICollection<CloseFriendProfile> GetAll()
        {
            return _context.CloseFriendProfile.ToList();
        }

        public CloseFriendProfile GetById(int id)
        {
            return _context.CloseFriendProfile.Find(id);
        }

        public void Update(CloseFriendProfile item)
        {
            _context.CloseFriendProfile.Update(item);
            _context.SaveChanges();
        }
    }
}