using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Business
{
    public class SearchUsersService
    {
        public IRepoInterface<User> UserRepo { get; }

        public SearchUsersService(IRepoInterface<User> userRepo)
        {
            this.UserRepo = userRepo;
        }

        public List<User> SearchUsers(string search, int loggedUserId)
        {
            List<User> allUsers = UserRepo.GetAll();
            List<User> searchResults = allUsers.FindAll((user) =>
                (user.FirstName.ToLower().Contains(search.ToLower()) ||
                user.LastName.ToLower().Contains(search.ToLower())) &&
                user.UserId != loggedUserId);

            return searchResults;
        }

        public User GetUserById(int userId)
        {
            return UserRepo.GetById(userId);
        }
    }
}
