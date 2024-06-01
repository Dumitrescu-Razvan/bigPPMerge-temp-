using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class FollowSuggestionRepository : IFollowSuggestionRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowSuggestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FollowSuggestion>> GetFollowSuggestionsAsync()
        {
            return await _context.FollowSuggestions.ToListAsync();
        }

        public async Task<FollowSuggestion> GetFollowSuggestionByIdAsync(int id)
        {
            return await _context.FollowSuggestions.FindAsync(id);
        }

        public async Task AddFollowSuggestionAsync(FollowSuggestion followSuggestion)
        {
            _context.FollowSuggestions.Add(followSuggestion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFollowSuggestionAsync(FollowSuggestion followSuggestion)
        {
            _context.Entry(followSuggestion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFollowSuggestionAsync(int id)
        {
            var followSuggestion = await _context.FollowSuggestions.FindAsync(id);
            if (followSuggestion != null)
            {
                _context.FollowSuggestions.Remove(followSuggestion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> FollowSuggestionExistsAsync(int id)
        {
            return await _context.FollowSuggestions.AnyAsync(e => e.Id == id);
        }
    }
}
