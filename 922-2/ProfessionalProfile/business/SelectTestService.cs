using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.RepoInterfaces;

namespace ProfessionalProfile.Business
{
    public class SelectTestService
    {
        private IAnswerRepoInterface<Answer> AnswerRepo { get; }
        private IQuestionRepoInterface<Question> QuestionRepo { get; }
        private IAssessmentTestRepoInterface<AssessmentTest> AssessmentTestRepo { get; }
        private ISkillRepoInterface<Skill> SkillRepo { get; }

        public SelectTestService()
        {
            this.AssessmentTestRepo = new AssessmentTestRepo();
            this.QuestionRepo = new QuestionRepo();
            this.AnswerRepo = new AnswerRepo();
            this.SkillRepo = new SkillRepo();
        }

        public SelectTestService(IAnswerRepoInterface<Answer> answerRepo, IQuestionRepoInterface<Question> questionRepo, IAssessmentTestRepoInterface<AssessmentTest> assessmentTestRepo, ISkillRepoInterface<Skill> skillRepo)
        {
            this.AnswerRepo = answerRepo;
            this.QuestionRepo = questionRepo;
            this.AssessmentTestRepo = assessmentTestRepo;
            this.SkillRepo = skillRepo;
        }

        public List<AssessmentTest> GetAllAssessmentTests()
        {
            return AssessmentTestRepo.GetAll();
        }

        public AssessmentTest GetAssessmentByName(string testName)
        {
            int id = AssessmentTestRepo.GetIdByName(testName);
            return AssessmentTestRepo.GetById(id);
        }

        public Skill GetSkillById(int id)
        {
            return SkillRepo.GetById(id);
        }
    }
}
