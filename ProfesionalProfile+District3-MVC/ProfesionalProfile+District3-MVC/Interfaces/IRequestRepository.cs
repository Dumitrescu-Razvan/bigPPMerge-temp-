

using ProfesionalProfile_District3_MVC.Models;

namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface IRequestRepository
    {
        Task AddRequestAsync(Request request);
        Task DeleteRequestAsync(int id);
        Task<Request> GetRequestByIdAsync(int id);
        Task<IEnumerable<Request>> GetRequestsAsync();
        Task<bool> RequestExistsAsync(int id);
        Task UpdateRequestAsync(Request request);
    }
}