using Microsoft.EntityFrameworkCore;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.UserThings
{
    public class UsersRepositoryGAMBA : IUsersRepositoryGAMBA
    {
        private readonly ApplicationDbContext _context;

        public UsersRepositoryGAMBA(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserGAMBA>> GetAllUsersAsync()
        {
            return await _context.userGAMBA.ToListAsync();
        }

        public async Task<UserGAMBA> GetUserByIdAsync(int id)
        {
            return await _context.userGAMBA.FindAsync(id);
        }

        public async Task CreateUserAsync(UserGAMBA user)
        {
            _context.userGAMBA.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserGAMBA user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.userGAMBA.FindAsync(id);
            if (user != null)
            {
                _context.userGAMBA.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            return await _context.userGAMBA.AnyAsync(e => e.Id == id);
        }
    }
}
