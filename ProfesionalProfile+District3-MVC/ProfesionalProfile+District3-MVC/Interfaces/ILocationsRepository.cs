
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface ILocationsRepository
    {
        Task AddLocationAsync(Location location);
        Task DeleteLocationAsync(int id);
        Task<Location> GetLocationByIdAsync(int id);
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<bool> LocationExistsAsync(int id);
        Task UpdateLocationAsync(Location location);
    }
}