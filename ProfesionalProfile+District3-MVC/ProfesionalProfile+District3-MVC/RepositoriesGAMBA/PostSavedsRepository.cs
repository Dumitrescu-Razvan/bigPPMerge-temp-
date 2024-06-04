using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class PostavedsRepository : IPostavedsRepository
    {
        private readonly ApplicationDbContext _context;

        public PostavedsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Postaved>> GetPostavedAsync()
        {
            return await _context.Postaved.ToListAsync();
        }

        public async Task<Postaved> GetPostavedByIdAsync(int id)
        {
            return await _context.Postaved.FindAsync(id);
        }

        public async Task AddPostavedAsync(Postaved Postaved)
        {
            _context.Postaved.Add(Postaved);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostavedAsync(Postaved Postaved)
        {
            _context.Entry(Postaved).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostavedAsync(int id)
        {
            var Postaved = await _context.Postaved.FindAsync(id);
            if (Postaved != null)
            {
                _context.Postaved.Remove(Postaved);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> PostavedExistsAsync(int id)
        {
            return await _context.Postaved.AnyAsync(e => e.save_id == id);
        }
    }
}
