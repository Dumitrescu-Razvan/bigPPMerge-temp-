using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class PostSavedsRepository : IPostSavedsRepository
    {
        private readonly ApplicationDbContext _context;

        public PostSavedsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostSaved>> GetPostSavedAsync()
        {
            return await _context.PostSaved.ToListAsync();
        }

        public async Task<PostSaved> GetPostSavedByIdAsync(int id)
        {
            return await _context.PostSaved.FindAsync(id);
        }

        public async Task AddPostSavedAsync(PostSaved postSaved)
        {
            _context.PostSaved.Add(postSaved);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostSavedAsync(PostSaved postSaved)
        {
            _context.Entry(postSaved).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostSavedAsync(int id)
        {
            var postSaved = await _context.PostSaved.FindAsync(id);
            if (postSaved != null)
            {
                _context.PostSaved.Remove(postSaved);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> PostSavedExistsAsync(int id)
        {
            return await _context.PostSaved.AnyAsync(e => e.save_id == id);
        }
    }
}
