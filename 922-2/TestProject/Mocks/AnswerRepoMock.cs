using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.RepoInterfaces;

namespace TestProject.Mocks
{
    public class AnswerRepoMock : IAnswerRepoInterface<Answer>
    {
        private List<Answer> answerVector;

        public AnswerRepoMock()
        {
            answerVector = new List<Answer>();
        }

        public void Add(Answer item)
        {
            answerVector.Add(item);
        }

        public List<Answer> GetAnswers(int questionId)
        {
            List<Answer> answers = new List<Answer>();
            foreach (Answer answer in answerVector)
            {
                if (answer.QuestionId == questionId)
                {
                    answers.Add(answer);
                }
            }
            return answers;
        }

        public void Delete(int id)
        {
        }

        public List<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Answer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Answer item)
        {
        }
    }
}
