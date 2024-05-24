using ProfessionalProfile.Business;
using ProfessionalProfile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TestProject.MockedRepo;

namespace TestProject
{
    public class CreateAssessmentTests
    {
        [Fact]
        public void CreateAssessmentTest_AsignsCorrectly()
        {
            QuestionTestRepoMock questionTestRepoMock = new QuestionTestRepoMock();
            SkillTestRepoMock skillTestRepoMock = new SkillTestRepoMock();
            AssessmentTestRepoMock assessmentTestRepoMock = new AssessmentTestRepoMock();
            AnswerTestRepoMock answerTestRepoMock = new AnswerTestRepoMock();

            CreateAssessmentService createAssessment = new CreateAssessmentService(answerTestRepoMock, questionTestRepoMock, assessmentTestRepoMock, skillTestRepoMock);
        
            Assert.NotNull(createAssessment);
        }

        [Fact]
        public void GetAllSkills_ReturnsSkillListTheyHardcoded()
        {
            QuestionTestRepoMock questionTestRepoMock = new QuestionTestRepoMock();
            SkillTestRepoMock skillTestRepoMock = new SkillTestRepoMock();
            AssessmentTestRepoMock assessmentTestRepoMock = new AssessmentTestRepoMock();
            AnswerTestRepoMock answerTestRepoMock = new AnswerTestRepoMock();

            CreateAssessmentService createAssessment = new CreateAssessmentService(answerTestRepoMock, questionTestRepoMock, assessmentTestRepoMock, skillTestRepoMock);

            List<Skill> expectedSkills = new List<Skill>();
            expectedSkills.Add(new Skill(1, "Python"));
            expectedSkills.Add(new Skill(2, "C++"));

            List<Skill> actualSkills = createAssessment.GetAllSkills();

            Assert.Equal(expectedSkills, actualSkills);
        }

        [Fact]
        public void CreateAssessmentTest_CreatesAssessmentTest()
        {
            QuestionTestRepoMock questionTestRepoMock = new QuestionTestRepoMock();
            SkillTestRepoMock skillTestRepoMock = new SkillTestRepoMock();
            AssessmentTestRepoMock assessmentTestRepoMock = new AssessmentTestRepoMock();
            AnswerTestRepoMock answerTestRepoMock = new AnswerTestRepoMock();
            
            skillTestRepoMock.Add(new Skill(1, "Python"));

            CreateAssessmentService createAssessment = new CreateAssessmentService(answerTestRepoMock, questionTestRepoMock, assessmentTestRepoMock, skillTestRepoMock);

            List<QuestionDTO> questionDTOs = new List<QuestionDTO>();
            List<AnswerDTO> answerDtos = new List<AnswerDTO>();
            AnswerDTO answerDto = new AnswerDTO("answer", true);
            answerDtos.Add(answerDto);
            questionDTOs.Add(new QuestionDTO("QuestionText", answerDtos, new AnswerDTO("CorrectAnswer", true)));

            AssessmentTestDTO assessmentTestDTO = new AssessmentTestDTO("TestName", "Description", questionDTOs, "Python");

            createAssessment.CreateAssessmentTest(assessmentTestDTO, 1);

            AssessmentTest actualAssessmentTest = assessmentTestRepoMock.GetAll().First();

            int expectedUserID = 1;
            int expectedSkillId = 1;

            Assert.Equal(expectedUserID, actualAssessmentTest.UserId);
            Assert.Equal("TestName", actualAssessmentTest.TestName);
            Assert.Equal("Description", actualAssessmentTest.Description);
            Assert.Equal(expectedSkillId, actualAssessmentTest.Skillid);
        }

        [Fact]
        public void CreateQuestion_CreatesQuestionProperly()
        {
            QuestionTestRepoMock questionTestRepoMock = new QuestionTestRepoMock();
            SkillTestRepoMock skillTestRepoMock = new SkillTestRepoMock();
            AssessmentTestRepoMock assessmentTestRepoMock = new AssessmentTestRepoMock();
            AnswerTestRepoMock answerTestRepoMock = new AnswerTestRepoMock();

            CreateAssessmentService createAssessment = new CreateAssessmentService(answerTestRepoMock, questionTestRepoMock, assessmentTestRepoMock, skillTestRepoMock);

            QuestionDTO questionDTO = new QuestionDTO("QuestionText", new List<AnswerDTO>(), new AnswerDTO("CorrectAnswer", true));

            createAssessment.CreateQuestion(questionDTO, 1);

            Question actualQuestion = questionTestRepoMock.GetAll().First();

            Assert.Equal("QuestionText", actualQuestion.QuestionText);
            Assert.Equal(1, actualQuestion.AssesmentTestId);
        }

        [Fact]
        public void GetAllActualSkills_ReturnsTheRepo()
        {
            QuestionTestRepoMock questionTestRepoMock = new QuestionTestRepoMock();
            SkillTestRepoMock skillTestRepoMock = new SkillTestRepoMock();
            AssessmentTestRepoMock assessmentTestRepoMock = new AssessmentTestRepoMock();
            AnswerTestRepoMock answerTestRepoMock = new AnswerTestRepoMock();

            skillTestRepoMock.Add(new Skill(1, "Python"));
            skillTestRepoMock.Add(new Skill(2, "C++"));
            skillTestRepoMock.Add(new Skill(3, "Java"));

            CreateAssessmentService createAssessment = new CreateAssessmentService(answerTestRepoMock, questionTestRepoMock, assessmentTestRepoMock, skillTestRepoMock);

            List<Skill> expectedResult = new List<Skill>();
            expectedResult.Add(new Skill(1, "Python"));
            expectedResult.Add(new Skill(2, "C++"));
            expectedResult.Add(new Skill(3, "Java"));

            List<Skill> actualResult = createAssessment.ActualGetAllSkills();

            Assert.Equal(expectedResult, actualResult);
        }

        private object GetPrivateProperty(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return property.GetValue(obj);
        }
    }
}
