using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class TrendingFeedRepository : ITrendingFeedRepository
    {
        private readonly ApplicationDbContext _context;

        public TrendingFeedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrendingFeed>> GetTrendingFeedsAsync()
        {
            return await _context.TrendingFeeds.ToListAsync();
        }

        public async Task<TrendingFeed> GetTrendingFeedByIdAsync(int id)
        {
            return await _context.TrendingFeeds.FindAsync(id);
        }

        public async Task AddTrendingFeedAsync(TrendingFeed trendingFeed)
        {
            _context.TrendingFeeds.Add(trendingFeed);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTrendingFeedAsync(TrendingFeed trendingFeed)
        {
            _context.Entry(trendingFeed).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrendingFeedAsync(int id)
        {
            var trendingFeed = await _context.TrendingFeeds.FindAsync(id);
            if (trendingFeed != null)
            {
                _context.TrendingFeeds.Remove(trendingFeed);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> TrendingFeedExistsAsync(int id)
        {
            return await _context.TrendingFeeds.AnyAsync(e => e.ID == id);
        }
    }
}
