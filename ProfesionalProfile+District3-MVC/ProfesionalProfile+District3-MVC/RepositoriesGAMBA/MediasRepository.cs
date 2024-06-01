using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;


namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class MediasRepository : IMediasRepository
    {
        private readonly ApplicationDbContext _context;

        public MediasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> GetMediasAsync()
        {
            return await _context.Media.ToListAsync();
        }

        public async Task<Media> GetMediaByIdAsync(int id)
        {
            return await _context.Media.FindAsync(id);
        }

        public async Task AddMediaAsync(Media media)
        {
            _context.Media.Add(media);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMediaAsync(Media media)
        {
            _context.Entry(media).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMediaAsync(int id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media != null)
            {
                _context.Media.Remove(media);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> MediaExistsAsync(int id)
        {
            return await _context.Media.AnyAsync(e => e.Id == id);
        }
    }
}
