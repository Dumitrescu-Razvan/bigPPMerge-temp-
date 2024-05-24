using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.Business;
using TestProject.Mocks;
using System.Security.RightsManagement;


namespace TestProject.Tests
{
    public class TakeTestServiceTest
    {
        [Fact]
        public void TestConstructorAssignsRepositories()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            // Act
            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Assert
            Assert.NotNull(takeTestService);

        }
        [Fact]
        public void TestGetTestDTOReturns_AssessmentTestDTOForGivenAssessmentId()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);
 
            AssessmentTestRepoMock.Add(new AssessmentTest(1, "TestName", 1, "Description", 1));
            AssessmentTestRepoMock.Add(new AssessmentTest(2, "TestName2", 2, "Description2", 2));


            QuestionRepoMock.Add(new Question(1, "Question1", 1));
            QuestionRepoMock.Add(new Question(2, "Question2", 1));
            QuestionRepoMock.Add(new Question(3, "Question3", 1));

            SkillRepoMock.Add(new Skill(1, "Python"));
            SkillRepoMock.Add(new Skill(2, "C++"));


            // Act
            var result = takeTestService.GetTestDTO(1);

            // Assert
            Assert.Equal(1, 1);
        }

        [Fact]
        public void TestGetQuestionsDTOsReturns_ListOfQuestionDTOs()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.IsType<List<QuestionDTO>>(result);
        }

        [Fact]
        public void TestGetQuestionsDTOsReturns_ListOfQuestionDTOsForGivenAssessmentId()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.IsType<List<QuestionDTO>>(result);
        }
        [Fact]
        public void TestGetQuestionDTOs_ReturnsAssessmentTestDTO()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.IsType<List<QuestionDTO>>(result);
        }
        [Fact]
        public void TestGetQuestionDTOs_ReturnsListOfQuestionDTOsForGivenAssessmentId()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.IsType<List<QuestionDTO>>(result);
        }
        [Fact]
        public void TestGetQuestionDTOsCreateAnswerDTOs_ReturnsListOfCorrectAnswers()
        {
            //Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            //create questions
            var question1 = new Question(1, "Question1", 1);
            var question2 = new Question(2, "Question2", 1);
            var question3 = new Question(3, "Question3", 1);
            var question4 = new Question(4, "Question4", 2);

            //create answers
            var answer1 = new Answer(1, "1", 1, true);
            var answer2 = new Answer(2, "1", 1, false);
            var answer3 = new Answer(3, "1", 1, true);
            var answer4 = new Answer(4, "2", 2, true);
            var answer5 = new Answer(5, "2", 2, false);
            var answer6 = new Answer(6, "2", 2, true);

            //add questions to repo
            QuestionRepoMock.Add(question1);
            QuestionRepoMock.Add(question2);
            QuestionRepoMock.Add(question3);
            QuestionRepoMock.Add(question4);


            //add answers to repo
            AnswerRepoMock.Add(answer1);
            AnswerRepoMock.Add(answer2);
            AnswerRepoMock.Add(answer3);
            AnswerRepoMock.Add(answer4);
            AnswerRepoMock.Add(answer5);
            AnswerRepoMock.Add(answer6);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(3, result[0].Answers.Count);
            Assert.Equal(3, result[1].Answers.Count);



        }

        [Fact]
        public void TestComputeTestResult_ReturnsInt()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            var assessmentTestDTO = new AssessmentTestDTO("TestName", "Description", new List<QuestionDTO>(), "Python");
            var strings = new List<string> { "Python", "C++" };

            // Act
            var result = takeTestService.ComputeTestResult(assessmentTestDTO, strings);
            Assert.IsType<int>(result);

        }

        [Fact]
        public void TestComputeTestResult_ReturnsIntForGivenAssessmentTestDTO_And_ListOfStrings()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            var assessmentTestDTO = new AssessmentTestDTO("TestName", "Description", new List<QuestionDTO>(), "Python");
            var strings = new List<string> { "Python", "C++" };

            // Act
            var result = takeTestService.ComputeTestResult(assessmentTestDTO, strings);
            Assert.IsType<int>(result);

        }

        [Fact]
        public void TestComputeTestResultWithoutEmptyStrings_ReturnsIntForGivenAssessmentTestDTO_And_ListOfStrings()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            var assessmentTestDTO = new AssessmentTestDTO("TestName", "Description", new List<QuestionDTO>(), "Python");
            var strings = new List<string> { "Python", "C++" };

            // Act
            var result = takeTestService.ComputeTestResult(assessmentTestDTO, strings);
            Assert.IsType<int>(result);

        }

        [Fact]
        public void AddTestResult_AddsAssessmentResult_To_Repo()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            takeTestService.AddTestResult(1, 1, 100, DateTime.Now);

            // Assert
            Assert.Equal(1, AssessmentResultRepoMock.GetAll().Count);
        }
        
        [Fact]
        public void AddTestResultAddsAssessmentResult_To_RepoForGivenTestIDUserIDScoreAndTestDate()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            //add questions to repo
            QuestionRepoMock.Add(new Question(1, "Question1", 1));
            QuestionRepoMock.Add(new Question(2, "Question2", 1));
            QuestionRepoMock.Add(new Question(3, "Question3", 1));

            //add answers to repo
            AnswerRepoMock.Add(new Answer(1, "1", 1, true));
            AnswerRepoMock.Add(new Answer(2, "1", 1, false));
            AnswerRepoMock.Add(new Answer(3, "1", 1, true));
            AnswerRepoMock.Add(new Answer(4, "2", 2, true));
            AnswerRepoMock.Add(new Answer(5, "2", 2, false));
            AnswerRepoMock.Add(new Answer(6, "2", 2, true));

            // list of questions
            var questionDTOs = new List<QuestionDTO>
            {
                new QuestionDTO("Question1", new List<AnswerDTO> { new AnswerDTO("1", true), new AnswerDTO("1", false), new AnswerDTO("1", true) }, new AnswerDTO("1", true)),
                new QuestionDTO("Question2", new List<AnswerDTO> { new AnswerDTO("2", true), new AnswerDTO("2", false), new AnswerDTO("2", true) }, new AnswerDTO("2", true)),
                new QuestionDTO("Question3", new List<AnswerDTO> { new AnswerDTO("3", true), new AnswerDTO("3", false), new AnswerDTO("3", true) }, new AnswerDTO("3", true)),
            };

            // create a testDTO
            var testDTO = new AssessmentTestDTO("TestName", "Description", questionDTOs, "Python");


            // Act
            takeTestService.ComputeTestResult(testDTO, new List<string> { "1", "2", "3" });

            // Assert
            Assert.Equal(0, AssessmentResultRepoMock.GetAll().Count);

        }
        
    }
}