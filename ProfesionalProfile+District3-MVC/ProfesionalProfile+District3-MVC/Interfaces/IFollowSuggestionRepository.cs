
using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IFollowSuggestionRepository
    {
        Task AddFollowSuggestionAsync(FollowSuggestion followSuggestion);
        Task DeleteFollowSuggestionAsync(int id);
        Task<bool> FollowSuggestionExistsAsync(int id);
        Task<FollowSuggestion> GetFollowSuggestionByIdAsync(int id);
        Task<IEnumerable<FollowSuggestion>> GetFollowSuggestionsAsync();
        Task UpdateFollowSuggestionAsync(FollowSuggestion followSuggestion);
    }
}