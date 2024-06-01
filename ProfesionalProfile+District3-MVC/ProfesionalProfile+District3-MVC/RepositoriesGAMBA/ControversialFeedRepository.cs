using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class ControversialFeedRepository : IControversialFeedRepository
    {
        private readonly ApplicationDbContext _context;

        public ControversialFeedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ControversialFeed>> GetControversialFeedsAsync()
        {
            return await _context.ControversialFeeds.ToListAsync();
        }

        public async Task<ControversialFeed> GetControversialFeedByIdAsync(int id)
        {
            return await _context.ControversialFeeds.FindAsync(id);
        }

        public async Task AddControversialFeedAsync(ControversialFeed controversialFeed)
        {
            _context.ControversialFeeds.Add(controversialFeed);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateControversialFeedAsync(ControversialFeed controversialFeed)
        {
            _context.Entry(controversialFeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControversialFeedExists(controversialFeed.ID))
                {
                    throw new KeyNotFoundException("ControversialFeed not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteControversialFeedAsync(int id)
        {
            var controversialFeed = await _context.ControversialFeeds.FindAsync(id);
            if (controversialFeed == null)
            {
                throw new KeyNotFoundException("ControversialFeed not found");
            }

            _context.ControversialFeeds.Remove(controversialFeed);
            await _context.SaveChangesAsync();
        }

        public bool ControversialFeedExists(int id)
        {
            return _context.ControversialFeeds.Any(e => e.ID == id);
        }
    }
}
