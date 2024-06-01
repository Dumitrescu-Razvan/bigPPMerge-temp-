using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class PostsGAMBARepository : IPostGAMBARepository
    {
        private readonly ApplicationDbContext _context;

        public PostsGAMBARepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostsGAMBA>> GetPostsAsync()
        {
            return await _context.PostsGAMBA.ToListAsync();
        }

        public async Task<PostsGAMBA> GetPostByIdAsync(int id)
        {
            return await _context.PostsGAMBA.FindAsync(id);
        }

        public async Task AddPostAsync(PostsGAMBA post)
        {
            _context.PostsGAMBA.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(PostsGAMBA post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.PostsGAMBA.FindAsync(id);
            if (post != null)
            {
                _context.PostsGAMBA.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> PostExistsAsync(int id)
        {
            return await _context.PostsGAMBA.AnyAsync(e => e.Post_Id == id);
        }
    }
}
