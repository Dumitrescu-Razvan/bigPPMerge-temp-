
using ProfesionalProfile_District3_MVC.Models;
namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IFollowsRepository
    {
        Task AddFollowAsync(Follow follow);
        Task DeleteFollowAsync(int id);
        Task<bool> FollowExistsAsync(int id);
        Task<Follow> GetFollowByIdAsync(int id);
        Task<IEnumerable<Follow>> GetFollowsAsync();
        Task UpdateFollowAsync(Follow follow);
    }
}