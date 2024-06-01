using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IFollowingFeedRepository
    {
        Task AddFollowingFeedAsync(FollowingFeed followingFeed);
        Task DeleteFollowingFeedAsync(int id);
        Task<bool> FollowingFeedExistsAsync(int id);
        Task<FollowingFeed> GetFollowingFeedByIdAsync(int id);
        Task<IEnumerable<FollowingFeed>> GetFollowingFeedsAsync();
        Task UpdateFollowingFeedAsync(FollowingFeed followingFeed);
    }
}