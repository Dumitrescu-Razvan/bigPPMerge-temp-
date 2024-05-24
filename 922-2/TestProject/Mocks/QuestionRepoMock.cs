using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.RepoInterfaces;

namespace ProfessionalProfile.Repo
{
    internal class QuestionRepoMock : IQuestionRepoInterface<Question>
    {
        private List<Question> questions;

        public QuestionRepoMock()
        {
            questions = new List<Question>();
        }

        public void Add(Question item)
        {
            questions.Add(item);
        }

        public int GetIdByNameAndAssessmentId(string questionName, int assessmentId)
        {
            int questionId = 0;

            foreach (Question question in questions)
            {
                if (question.QuestionText == questionName && question.AssesmentTestId == assessmentId)
                {
                    questionId = question.QuestionId;
                    break;
                }
            }

            return questionId;
        }

        public void Delete(int id)
        {
        }

        public List<Question> GetAllByTestId(int testID)
        {
            return questions.Where(q => q.AssesmentTestId == testID).ToList();
        }

        public List<Question> GetAll()
        {
            return questions;
        }

        public Question GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Question item)
        {
        }
    }
}
