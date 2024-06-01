using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class PostReportedRepository : IPostReportedRepository
    {
        private readonly ApplicationDbContext _context;

        public PostReportedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostReported>> GetPostReportedAsync()
        {
            return await _context.PostReported.ToListAsync();
        }

        public async Task<PostReported> GetPostReportedByIdAsync(int id)
        {
            return await _context.PostReported.FindAsync(id);
        }

        public async Task AddPostReportedAsync(PostReported postReported)
        {
            _context.PostReported.Add(postReported);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostReportedAsync(PostReported postReported)
        {
            _context.Entry(postReported).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostReportedAsync(int id)
        {
            var postReported = await _context.PostReported.FindAsync(id);
            if (postReported != null)
            {
                _context.PostReported.Remove(postReported);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> PostReportedExistsAsync(int id)
        {
            return await _context.PostReported.AnyAsync(e => e.Report_Id == id);
        }
    }
}
