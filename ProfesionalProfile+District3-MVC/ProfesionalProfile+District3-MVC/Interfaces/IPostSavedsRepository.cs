

using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IPostSavedsRepository
    {
        Task AddPostSavedAsync(PostSaved postSaved);
        Task DeletePostSavedAsync(int id);
        Task<IEnumerable<PostSaved>> GetPostSavedAsync();
        Task<PostSaved> GetPostSavedByIdAsync(int id);
        Task<bool> PostSavedExistsAsync(int id);
        Task UpdatePostSavedAsync(PostSaved postSaved);
    }
}