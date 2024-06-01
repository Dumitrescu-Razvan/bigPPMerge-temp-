using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class PostArchivedRepository : IPostArchivedRepository
    {
        private readonly ApplicationDbContext _context;

        public PostArchivedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostArchived>> GetPostArchivedAsync()
        {
            return await _context.PostArchived.ToListAsync();
        }

        public async Task<PostArchived> GetPostArchivedByIdAsync(int id)
        {
            return await _context.PostArchived.FindAsync(id);
        }

        public async Task AddPostArchivedAsync(PostArchived postArchived)
        {
            _context.PostArchived.Add(postArchived);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostArchivedAsync(PostArchived postArchived)
        {
            _context.Entry(postArchived).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostArchivedAsync(int id)
        {
            var postArchived = await _context.PostArchived.FindAsync(id);
            if (postArchived != null)
            {
                _context.PostArchived.Remove(postArchived);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> PostArchivedExistsAsync(int id)
        {
            return await _context.PostArchived.AnyAsync(e => e.post_id == id);
        }
    }
}
