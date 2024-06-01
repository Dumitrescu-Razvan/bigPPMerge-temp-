

using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IUsersRepositoryGAMBA
    {
        Task CreateUserAsync(UserGAMBA user);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserGAMBA>> GetAllUsersAsync();
        Task<UserGAMBA> GetUserByIdAsync(int id);
        Task UpdateUserAsync(UserGAMBA user);
        Task<bool> UserExistsAsync(int id);
    }
}