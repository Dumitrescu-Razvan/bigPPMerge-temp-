using ProfesionalProfile_District3_MVC.Models;


namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IFeedConfigurationRepository
    {
        Task AddFeedConfigurationAsync(FeedConfiguration feedConfiguration);
        Task DeleteFeedConfigurationAsync(int id);
        bool FeedConfigurationExists(int id);
        Task<FeedConfiguration> GetFeedConfigurationByIdAsync(int id);
        Task<IEnumerable<FeedConfiguration>> GetFeedConfigurationsAsync();
        Task UpdateFeedConfigurationAsync(FeedConfiguration feedConfiguration);
    }
}