using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _context.Location.ToListAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _context.Location.FindAsync(id);
        }

        public async Task AddLocationAsync(Location location)
        {
            _context.Location.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await _context.Location.FindAsync(id);
            if (location != null)
            {
                _context.Location.Remove(location);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> LocationExistsAsync(int id)
        {
            return await _context.Location.AnyAsync(e => e.Id == id);
        }
    }
}
