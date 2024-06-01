using ProfesionalProfile_District3_MVC.Models;


namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IFollowedFeedFollowedUsersRepository
    {
        Task AddFollowedFeedFollowedUsersAsync(FollowedFeedFollowedUsers followedFeedFollowedUsers);
        Task DeleteFollowedFeedFollowedUsersAsync(int id);
        Task<bool> FollowedFeedFollowedUsersExistsAsync(int id);
        Task<IEnumerable<FollowedFeedFollowedUsers>> GetFollowedFeedFollowedUsersAsync();
        Task<FollowedFeedFollowedUsers> GetFollowedFeedFollowedUsersByIdAsync(int id);
        Task UpdateFollowedFeedFollowedUsersAsync(FollowedFeedFollowedUsers followedFeedFollowedUsers);
    }
}