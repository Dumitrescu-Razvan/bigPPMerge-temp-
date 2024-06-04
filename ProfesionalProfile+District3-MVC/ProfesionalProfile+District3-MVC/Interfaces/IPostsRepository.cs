
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IPostRepository
    {
        Task AddPostAsync(PostGAMBA post);
        Task DeletePostAsync(int id);
        Task<PostGAMBA> GetPostByIdAsync(int id);
        Task<IEnumerable<PostGAMBA>> GetPostAsync();
        Task<bool> PostExistsAsync(int id);
        Task UpdatePostAsync(PostGAMBA post);
    }
}