
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IPostArchivedRepository
    {
        Task AddPostArchivedAsync(PostArchived postArchived);
        Task DeletePostArchivedAsync(int id);
        Task<IEnumerable<PostArchived>> GetPostArchivedAsync();
        Task<PostArchived> GetPostArchivedByIdAsync(int id);
        Task<bool> PostArchivedExistsAsync(int id);
        Task UpdatePostArchivedAsync(PostArchived postArchived);
    }
}