using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class PostGAMBARepository : IPostGAMBARepository
    {
        private readonly ApplicationDbContext _context;

        public PostGAMBARepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostGAMBA>> GetPostAsync()
        {
            return await _context.PostGAMBA.ToListAsync();
        }

        public async Task<PostGAMBA> GetPostByIdAsync(int id)
        {
            return await _context.PostGAMBA.FindAsync(id);
        }

        public async Task AddPostAsync(PostGAMBA post)
        {
            _context.PostGAMBA.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(PostGAMBA post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.PostGAMBA.FindAsync(id);
            if (post != null)
            {
                _context.PostGAMBA.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> PostExistsAsync(int id)
        {
            return await _context.PostGAMBA.AnyAsync(e => e.Post_Id == id);
        }
    }
}
