using ProfesionalProfile_District3_MVC.Models;


namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IControversialFeedRepository
    {
        Task AddControversialFeedAsync(ControversialFeed controversialFeed);
        bool ControversialFeedExists(int id);
        Task DeleteControversialFeedAsync(int id);
        Task<ControversialFeed> GetControversialFeedByIdAsync(int id);
        Task<IEnumerable<ControversialFeed>> GetControversialFeedsAsync();
        Task UpdateControversialFeedAsync(ControversialFeed controversialFeed);
    }
}