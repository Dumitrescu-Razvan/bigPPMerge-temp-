using ProfessionalProfile.Domain;
using System.DirectoryServices.ActiveDirectory;
using TestProject.RepoMocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Business;
using TestProject.RepoMocks;

namespace TestProject.TestServices
{
    public class SearchUsersServiceTest
    {
        // This is a test service that will be used to test the SearchUsersService
        [Fact]
        public void SearchUsersService_SearchUsers_UsersFound()
        {
            // Arrange
            User user1 = new User(1, "John", "Doe", "johndoe@gmail.com", "password", "1234567890", "About me", DateTime.Parse("01/01/2002"), false, "Cluj-Napoca", "website", "picture");
            User user2 = new User(2, "Jane", "Doe", "janedoe@gmail.com", "password", "1234567890", "About me", DateTime.Parse("01/01/2002"), false, "Cluj-Napoca", "website", "picture");

            SearchUsersService searchUsersService = new SearchUsersService(new UserRepoMock());
            searchUsersService.UserRepo.Add(user1);
            searchUsersService.UserRepo.Add(user2);

            // Act
            List<User> searchResults = searchUsersService.SearchUsers("Jane", 1);

            // Assert
            Assert.Single(searchResults);
            Assert.Equal("Jane", searchResults[0].FirstName);
            Assert.Equal("Doe", searchResults[0].LastName);

        }

        [Fact]
        public void SearchUsersService_GetUserById_UserFound()
        {
            // Arrange
            User user1 = new User(1, "John", "Doe", "johndoe@gmail.com", "password", "1234567890", "About me", DateTime.Parse("01/01/2002"), false, "Cluj-Napoca", "website", "picture");

            SearchUsersService searchUsersService = new SearchUsersService(new UserRepoMock());
            searchUsersService.UserRepo.Add(user1);

            // Act
            User user = searchUsersService.GetUserById(1);

            // Assert
            Assert.Equal("John", user.FirstName);
            Assert.Equal("Doe", user.LastName);
        }
    }
}

