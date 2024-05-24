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
    public class CreateAssessmentService
    {
        private IAnswerRepoInterface<Answer> AnswerRepo { get; }
        private IQuestionRepoInterface<Question> QuestionRepo { get; }
        private IAssessmentTestRepoInterface<AssessmentTest> AssessmentTestRepo { get; }
        private ISkillRepoInterface<Skill> SkillRepo { get; }

        /*public CreateAssessmentService()
        {
            this.AssessmentTestRepo = new AssessmentTestRepo();
            this.QuestionRepo = new QuestionRepo();
            this.AnswerRepo = new AnswerRepo();
            this.SkillRepo = new SkillRepo();
        }*/

        public CreateAssessmentService(IAnswerRepoInterface<Answer> answerRepo, IQuestionRepoInterface<Question> questionRepo, IAssessmentTestRepoInterface<AssessmentTest> assessmentTestRepo, ISkillRepoInterface<Skill> skillRepo)
        {
            this.AnswerRepo = answerRepo;
            this.QuestionRepo = questionRepo;
            this.AssessmentTestRepo = assessmentTestRepo;
            this.SkillRepo = skillRepo;
        }

        public List<Skill> GetAllSkills()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill(1, "Python"));
            skills.Add(new Skill(2, "C++"));

            return skills;
        }

        public List<Skill> ActualGetAllSkills()
        {
            return SkillRepo.GetAll();
        }

        public void CreateAssessmentTest(AssessmentTestDTO assessmentTestDTO, int userId)
        {
            int skillId = SkillRepo.GetIdByName(assessmentTestDTO.SkillTested);
            AssessmentTest assessmentTest = new AssessmentTest(0, assessmentTestDTO.TestName, userId, assessmentTestDTO.Description, skillId);

            AssessmentTestRepo.Add(assessmentTest);
            int assessmentTestId = AssessmentTestRepo.GetIdByName(assessmentTestDTO.TestName);

            foreach (QuestionDTO questionDTO in assessmentTestDTO.Questions)
            {
                CreateQuestion(questionDTO, assessmentTestId);
            }
        }

        public void CreateQuestion(QuestionDTO questionDTO, int assessmentId)
        {
            Question question = new Question(0, questionDTO.QuestionText, assessmentId);
            QuestionRepo.Add(question);
            int questionId = QuestionRepo.GetIdByNameAndAssessmentId(questionDTO.QuestionText, assessmentId);

            foreach (AnswerDTO answerDTO in questionDTO.Answers)
            {
                Answer answer = new Answer(0, answerDTO.AnswerText, questionId, answerDTO.AnswerText == questionDTO.CorrectAnswer.AnswerText);
                AnswerRepo.Add(answer);
            }
        }
    }
}
