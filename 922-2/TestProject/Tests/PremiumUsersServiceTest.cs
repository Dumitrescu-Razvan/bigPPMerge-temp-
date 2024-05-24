using System.Collections.Generic;
using ProfessionalProfile.Business;
using ProfessionalProfile.Repo;
using TestProject.Mocks;
using Moq;
using Xunit;

namespace TestProject.Tests
{
    public class PremiumUsersServiceTest
    {

        [Fact]
        public void GetAllPremiumUsersTest()
        {
            // Arrange
            var mockRepo = new PremiumUsersRepoMock();

            var service = new PremiumUsersService(mockRepo);

            service.AddPremiumUser(1);
            service.AddPremiumUser(2);
            service.AddPremiumUser(3);

            // Act
            var result = service.GetPremiumUsers();

            // Assert
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }

        [Fact]
        public void IsPremiumUserTest()
        {
            // Arrange
            var mockRepo = new PremiumUsersRepoMock();

            var service = new PremiumUsersService(mockRepo);

            service.AddPremiumUser(1);
            service.AddPremiumUser(2);
            service.AddPremiumUser(3);

            // Act
            var result = service.IsPremiumUser(2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddPremiumUserTest()
        {
            // Arrange
            var mockRepo = new PremiumUsersRepoMock();

            var service = new PremiumUsersService(mockRepo);

            // Act
            service.AddPremiumUser(1);
            var result = service.GetPremiumUsers();

            // Assert
            Assert.Contains(1, result);
        }

        [Fact]
        public void GetByIdTest()
        {
            // Arrange
            var mockRepo = new PremiumUsersRepoMock();

            mockRepo.Add(1);

            Assert.Throws<NotImplementedException>(() => mockRepo.GetById(1));
        }

        [Fact]
        public void UpdateTest()
        {
            // Arrange
            var mockRepo = new PremiumUsersRepoMock();

            mockRepo.Add(1);

            Assert.Throws<NotImplementedException>(() => mockRepo.Update(1));
        }

        [Fact]
        public void DeleteTest()
        {
            // Arrange
            var mockRepo = new PremiumUsersRepoMock();

            mockRepo.Add(1);

            Assert.Throws<NotImplementedException>(() => mockRepo.Delete(1));
        }
    }
}