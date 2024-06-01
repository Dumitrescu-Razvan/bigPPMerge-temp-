using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class FollowingFeedRepository : IFollowingFeedRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingFeedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FollowingFeed>> GetFollowingFeedsAsync()
        {
            return await _context.FollowingFeeds.ToListAsync();
        }

        public async Task<FollowingFeed> GetFollowingFeedByIdAsync(int id)
        {
            return await _context.FollowingFeeds.FindAsync(id);
        }

        public async Task AddFollowingFeedAsync(FollowingFeed followingFeed)
        {
            _context.FollowingFeeds.Add(followingFeed);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFollowingFeedAsync(FollowingFeed followingFeed)
        {
            _context.Entry(followingFeed).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFollowingFeedAsync(int id)
        {
            var followingFeed = await _context.FollowingFeeds.FindAsync(id);
            if (followingFeed != null)
            {
                _context.FollowingFeeds.Remove(followingFeed);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> FollowingFeedExistsAsync(int id)
        {
            return await _context.FollowingFeeds.AnyAsync(e => e.ID == id);
        }
    }
}
