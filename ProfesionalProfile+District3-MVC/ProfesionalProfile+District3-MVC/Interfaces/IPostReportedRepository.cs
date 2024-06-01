
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IPostReportedRepository
    {
        Task AddPostReportedAsync(PostReported postReported);
        Task DeletePostReportedAsync(int id);
        Task<IEnumerable<PostReported>> GetPostReportedAsync();
        Task<PostReported> GetPostReportedByIdAsync(int id);
        Task<bool> PostReportedExistsAsync(int id);
        Task UpdatePostReportedAsync(PostReported postReported);
    }
}