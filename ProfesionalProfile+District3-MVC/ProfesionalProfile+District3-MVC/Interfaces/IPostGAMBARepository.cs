using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IPostGAMBARepository
    {
        Task AddPostAsync(PostsGAMBA post);
        Task DeletePostAsync(int id);
        Task<PostsGAMBA> GetPostByIdAsync(int id);
        Task<IEnumerable<PostsGAMBA>> GetPostsAsync();
        Task<bool> PostExistsAsync(int id);
        Task UpdatePostAsync(PostsGAMBA post);
    }
}
