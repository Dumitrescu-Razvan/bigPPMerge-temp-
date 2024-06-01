using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class FollowsRepository : IFollowsRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Follow>> GetFollowsAsync()
        {
            return await _context.Follow.ToListAsync();
        }

        public async Task<Follow> GetFollowByIdAsync(int id)
        {
            return await _context.Follow.FindAsync(id);
        }

        public async Task AddFollowAsync(Follow follow)
        {
            _context.Follow.Add(follow);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFollowAsync(Follow follow)
        {
            _context.Entry(follow).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFollowAsync(int id)
        {
            var follow = await _context.Follow.FindAsync(id);
            if (follow != null)
            {
                _context.Follow.Remove(follow);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> FollowExistsAsync(int id)
        {
            return await _context.Follow.AnyAsync(e => e.Id == id);
        }
    }
}
