using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class FollowedFeedFollowedUsersRepository : IFollowedFeedFollowedUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowedFeedFollowedUsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FollowedFeedFollowedUsers>> GetFollowedFeedFollowedUsersAsync()
        {
            return await _context.FollowedFeedFollowedUsers.ToListAsync();
        }

        public async Task<FollowedFeedFollowedUsers> GetFollowedFeedFollowedUsersByIdAsync(int id)
        {
            return await _context.FollowedFeedFollowedUsers.FindAsync(id);
        }

        public async Task AddFollowedFeedFollowedUsersAsync(FollowedFeedFollowedUsers followedFeedFollowedUsers)
        {
            _context.FollowedFeedFollowedUsers.Add(followedFeedFollowedUsers);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFollowedFeedFollowedUsersAsync(FollowedFeedFollowedUsers followedFeedFollowedUsers)
        {
            _context.Entry(followedFeedFollowedUsers).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFollowedFeedFollowedUsersAsync(int id)
        {
            var followedFeedFollowedUsers = await _context.FollowedFeedFollowedUsers.FindAsync(id);
            if (followedFeedFollowedUsers != null)
            {
                _context.FollowedFeedFollowedUsers.Remove(followedFeedFollowedUsers);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> FollowedFeedFollowedUsersExistsAsync(int id)
        {
            return await _context.FollowedFeedFollowedUsers.AnyAsync(e => e.ID == id);
        }
    }
}
