
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface ITrendingFeedRepository
    {
        Task AddTrendingFeedAsync(TrendingFeed trendingFeed);
        Task DeleteTrendingFeedAsync(int id);
        Task<TrendingFeed> GetTrendingFeedByIdAsync(int id);
        Task<IEnumerable<TrendingFeed>> GetTrendingFeedsAsync();
        Task<bool> TrendingFeedExistsAsync(int id);
        Task UpdateTrendingFeedAsync(TrendingFeed trendingFeed);
    }
}