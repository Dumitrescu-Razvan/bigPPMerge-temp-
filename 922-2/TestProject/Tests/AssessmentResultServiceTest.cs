using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ProfessionalProfile.Business;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.RepoInterfaces;
using TestProject.MockedRepo;
using Xunit;



namespace TestProject
{
    public class AssessmentResultServiceTest
    {
        [Fact]
        public void GetResultsByUserIdTest_ReturnsTheProperList()
        {
            // Declare the mocked repositories that will be used
            AssesmmentResultRepoMock assessmentResultMockedRepositoryThatWillBeUsed = new AssesmmentResultRepoMock();
            MockedRepo.AssessmentTestRepoMock assessmentTestMockedRepositoryThatWillBeUsed = new MockedRepo.AssessmentTestRepoMock();

            // Create the AssessmentResults that will be used
            AssessmentResult assessmentResult = new AssessmentResult(1, 1, 1, 1, DateTime.Now);
            AssessmentResult assessmentResult1 = new AssessmentResult(2, 1, 1, 1, DateTime.Now);
            AssessmentResult assessmentResult2 = new AssessmentResult(3, 1, 1, 1, DateTime.Now);
            AssessmentResult assessmentResult3 = new AssessmentResult(4, 1, 1, 1, DateTime.Now);
            AssessmentResult assessmentResult4 = new AssessmentResult(5, 1, 1, 1, DateTime.Now);

            // Add the AssessmentResults to the mocked repository
            assessmentResultMockedRepositoryThatWillBeUsed.Add(assessmentResult);
            assessmentResultMockedRepositoryThatWillBeUsed.Add(assessmentResult1);
            assessmentResultMockedRepositoryThatWillBeUsed.Add(assessmentResult2);
            assessmentResultMockedRepositoryThatWillBeUsed.Add(assessmentResult3);
            assessmentResultMockedRepositoryThatWillBeUsed.Add(assessmentResult4);

            // Create the AssessmentResultsService object
            AssessmentResultsService assessmentResultsService = new AssessmentResultsService(assessmentResultMockedRepositoryThatWillBeUsed, assessmentTestMockedRepositoryThatWillBeUsed);

            // Create the expected result
            List<AssessmentResult> expectedResult = new List<AssessmentResult> { assessmentResult, assessmentResult1, assessmentResult2, assessmentResult3, assessmentResult4 };

            // Create the actual result
            List<AssessmentResult> actualResult = assessmentResultsService.GetResultsByUserId(1);

            // Assert the expected result and the actual result are equal
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestConstructorAssignsRepositories()
        {
            // Arrange
            var assessmentResultMock = new Mock<IAssessmentResultRepoInterface<AssessmentResult>>();
            var assessmentTestMock = new Mock<IAssessmentTestRepoInterface<AssessmentTest>>();

            // Act
            var assessmentResultsService = new AssessmentResultsService(assessmentResultMock.Object, assessmentTestMock.Object);

            // Assert
            Assert.NotNull(assessmentResultsService);
            Assert.Same(assessmentResultMock.Object, GetPrivateProperty(assessmentResultsService, "AssessmentResultRepo"));
            Assert.Same(assessmentTestMock.Object, GetPrivateProperty(assessmentResultsService, "AssessmentTestRepo"));
        }

        [Fact]
        public void TestGetTestById_ReturnsTheProperTest()
        {
            // Declare the mocked repositories that will be used
            AssesmmentResultRepoMock assessmentResultMockedRepositoryThatWillBeUsed = new AssesmmentResultRepoMock();
            MockedRepo.AssessmentTestRepoMock assessmentTestMockedRepositoryThatWillBeUsed = new MockedRepo.AssessmentTestRepoMock();

            // Create the AssessmentTests that will be used
            AssessmentTest assessmentTest = new AssessmentTest(1, "TestName", 1, "Description", 1);
            AssessmentTest assessmentTest1 = new AssessmentTest(2, "TestName1", 1, "Description", 1);
            AssessmentTest assessmentTest2 = new AssessmentTest(3, "TestName2", 1, "Description", 1);
            AssessmentTest assessmentTest3 = new AssessmentTest(4, "TestName3", 1, "Description", 1);
            AssessmentTest assessmentTest4 = new AssessmentTest(5, "TestName4", 1, "Description", 1);

            // Add the AssessmentTests to the mocked repository
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest);
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest1);
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest2);
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest3);
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest4);

            // Create the expected object
            AssessmentTest expectedResult = assessmentTest2;

            // Create the AssessmentResultsService object
            AssessmentResultsService assessmentResultsService = new AssessmentResultsService(assessmentResultMockedRepositoryThatWillBeUsed, assessmentTestMockedRepositoryThatWillBeUsed);

            // Create the actual result
            AssessmentTest actualResult = assessmentResultsService.GetTestById(3);

            // Assert the expected result and the actual result are equal
            Assert.Equal(actualResult, expectedResult);
        }

        [Fact]
        public void TestGetTestById_ReturnsNull()
        {
            // Declare the mocked repositories that will be used
            AssesmmentResultRepoMock assessmentResultMockedRepositoryThatWillBeUsed = new AssesmmentResultRepoMock();
            MockedRepo.AssessmentTestRepoMock assessmentTestMockedRepositoryThatWillBeUsed = new MockedRepo.AssessmentTestRepoMock();

            // Create the AssessmentTests that will be used
            AssessmentTest assessmentTest = new AssessmentTest(1, "TestName", 1, "Description", 1);
            AssessmentTest assessmentTest1 = new AssessmentTest(2, "TestName1", 1, "Description", 1);
            AssessmentTest assessmentTest2 = new AssessmentTest(3, "TestName2", 1, "Description", 1);
            AssessmentTest assessmentTest3 = new AssessmentTest(4, "TestName3", 1, "Description", 1);
            AssessmentTest assessmentTest4 = new AssessmentTest(5, "TestName4", 1, "Description", 1);

            // Add the AssessmentTests to the mocked repository
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest);
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest1);
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest2);
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest3);
            assessmentTestMockedRepositoryThatWillBeUsed.Add(assessmentTest4);

            // Create the expected object
            AssessmentTest expectedResult = null;

            // Create the AssessmentResultsService object
            AssessmentResultsService assessmentResultsService = new AssessmentResultsService(assessmentResultMockedRepositoryThatWillBeUsed, assessmentTestMockedRepositoryThatWillBeUsed);

            // Create the actual result
            int idThatDoesNotExist = 90;
            AssessmentTest actualResult = assessmentResultsService.GetTestById(idThatDoesNotExist);

            // Assert the expected result and the actual result are equal
            Assert.Equal(actualResult, expectedResult);
        }


        private object GetPrivateProperty(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return property.GetValue(obj);
        }
    }
}
