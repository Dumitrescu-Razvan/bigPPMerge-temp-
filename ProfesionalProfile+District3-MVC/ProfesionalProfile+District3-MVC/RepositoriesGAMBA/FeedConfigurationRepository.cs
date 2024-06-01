using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class FeedConfigurationRepository : IFeedConfigurationRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedConfigurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedConfiguration>> GetFeedConfigurationsAsync()
        {
            return await _context.FeedConfigurations.ToListAsync();
        }

        public async Task<FeedConfiguration> GetFeedConfigurationByIdAsync(int id)
        {
            return await _context.FeedConfigurations.FindAsync(id);
        }

        public async Task AddFeedConfigurationAsync(FeedConfiguration feedConfiguration)
        {
            _context.FeedConfigurations.Add(feedConfiguration);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFeedConfigurationAsync(FeedConfiguration feedConfiguration)
        {
            _context.Entry(feedConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedConfigurationExists(feedConfiguration.ID))
                {
                    throw new KeyNotFoundException("FeedConfiguration not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteFeedConfigurationAsync(int id)
        {
            var feedConfiguration = await _context.FeedConfigurations.FindAsync(id);
            if (feedConfiguration == null)
            {
                throw new KeyNotFoundException("FeedConfiguration not found");
            }

            _context.FeedConfigurations.Remove(feedConfiguration);
            await _context.SaveChangesAsync();
        }

        public bool FeedConfigurationExists(int id)
        {
            return _context.FeedConfigurations.Any(e => e.ID == id);
        }
    }
}
