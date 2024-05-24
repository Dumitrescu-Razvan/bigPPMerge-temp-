using ProfessionalProfile.Business;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.MockedRepo;

namespace TestProject.Tests
{
    public class SelectTestServiceTest
    {
        [Fact]  
        public void GetAllAssessmentTestsTest()
        {
            QuestionTestRepoMock questionTestRepoMock = new QuestionTestRepoMock();
            SkillTestRepoMock skillTestRepoMock = new SkillTestRepoMock();
            MockedRepo.AssessmentTestRepoMock assessmentTestRepoMock = new MockedRepo.AssessmentTestRepoMock();
            AnswerTestRepoMock answerTestRepoMock = new AnswerTestRepoMock();

            SelectTestService selectTestService = new SelectTestService(answerTestRepoMock, questionTestRepoMock, assessmentTestRepoMock, skillTestRepoMock);

            assessmentTestRepoMock.Add(new AssessmentTest(1, "programming", 1001, "evaluates programming skills", 3));
            assessmentTestRepoMock.Add(new AssessmentTest(2, "language proficiency", 2001, "proficiency in multiple languages", 5));
            assessmentTestRepoMock.Add(new AssessmentTest(3, "problem solving", 3001, "evaluates problem solving", 4));

            List<AssessmentTest> expectedResult = new List<AssessmentTest>();
            expectedResult.Add(new AssessmentTest(1, "programming", 1001, "evaluates programming skills", 3));
            expectedResult.Add(new AssessmentTest(2, "language proficiency", 2001, "proficiency in multiple languages", 5));
            expectedResult.Add(new AssessmentTest(3, "problem solving", 3001, "evaluates problem solving", 4));

            List<AssessmentTest> actualResult = selectTestService.GetAllAssessmentTests();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetAssessmentByNameTest()
        {

            QuestionTestRepoMock questionTestRepoMock = new QuestionTestRepoMock();
            SkillTestRepoMock skillTestRepoMock = new SkillTestRepoMock();
            MockedRepo.AssessmentTestRepoMock assessmentTestRepoMock = new MockedRepo.AssessmentTestRepoMock();
            AnswerTestRepoMock answerTestRepoMock = new AnswerTestRepoMock();

            SelectTestService selectTestService = new SelectTestService(answerTestRepoMock, questionTestRepoMock, assessmentTestRepoMock, skillTestRepoMock);

            string testNameToFind = "language proficiency";
            AssessmentTest expectedResult = new AssessmentTest(1, testNameToFind, 1001, "evaluates programming skills", 3);

            AssessmentTest actualResult = selectTestService.GetAssessmentByName(testNameToFind);

            Assert.Equal (actualResult, null);

        }

        [Fact]
        public void GetSkillByIdTest()
        {

            QuestionTestRepoMock questionTestRepoMock = new QuestionTestRepoMock();
            SkillTestRepoMock skillTestRepoMock = new SkillTestRepoMock();
            MockedRepo.AssessmentTestRepoMock assessmentTestRepoMock = new MockedRepo.AssessmentTestRepoMock();
            AnswerTestRepoMock answerTestRepoMock = new AnswerTestRepoMock();

            SelectTestService selectTestService = new SelectTestService(answerTestRepoMock, questionTestRepoMock, assessmentTestRepoMock, skillTestRepoMock);

            int skillIdToFind = 1; // Example skill ID to search for
            Skill expectedSkill = new Skill(skillIdToFind, "Programming"); // Example expected Skill object

            Skill actualSkill = selectTestService.GetSkillById(skillIdToFind);

            Assert.Equal (null, actualSkill);
        }
    }
}
