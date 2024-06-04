

using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IPostavedsRepository
    {
        Task AddPostavedAsync(Postaved Postaved);
        Task DeletePostavedAsync(int id);
        Task<IEnumerable<Postaved>> GetPostavedAsync();
        Task<Postaved> GetPostavedByIdAsync(int id);
        Task<bool> PostavedExistsAsync(int id);
        Task UpdatePostavedAsync(Postaved Postaved);
    }
}