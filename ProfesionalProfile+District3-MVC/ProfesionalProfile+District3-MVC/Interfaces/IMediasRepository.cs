using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IMediasRepository
    {
        Task AddMediaAsync(Media media);
        Task DeleteMediaAsync(int id);
        Task<Media> GetMediaByIdAsync(int id);
        Task<IEnumerable<Media>> GetMediasAsync();
        Task<bool> MediaExistsAsync(int id);
        Task UpdateMediaAsync(Media media);
    }
}