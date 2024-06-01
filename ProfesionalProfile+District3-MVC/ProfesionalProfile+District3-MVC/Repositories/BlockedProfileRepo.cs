using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class BlockedProfileRepository : IRepoInterface<BlockedProfile>
    {
        private readonly ApplicationDbContext _context;
        public BlockedProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(BlockedProfile item)
        {
            _context.BlockedProfile.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var blockedProfile = _context.BlockedProfile.Find(id);
            if (blockedProfile != null)
            {
                _context.BlockedProfile.Remove(blockedProfile);
                _context.SaveChanges();
            }
        }

        public ICollection<BlockedProfile> GetAll()
        {
            return _context.BlockedProfile.ToList();
        }

        public BlockedProfile GetById(int id)
        {
            return _context.BlockedProfile.Find(id);
        }

        public void Update(BlockedProfile item)
        {
            _context.BlockedProfile.Update(item);
            _context.SaveChanges();
        }
    }
}