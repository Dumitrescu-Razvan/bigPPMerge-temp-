using ProfessionalProfile.Domain;
using ProfessionalProfile.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockedRepo
{
    internal class AnswerTestRepoMock : IAnswerRepoInterface<Answer>
    {
        List<Answer> answers;

        public AnswerTestRepoMock()
        {
            answers = new List<Answer>();
        }

        public void Add(Answer item)
        {
            answers.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Answer> GetAll()
        {
            return this.answers;
        }

        public Answer GetById(int id)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].AnswerId == id)
                {
                    return answers[i];
                }
            }
            return null;
        }

        public int GetIdByName(string answerName)
        {
            return this.answers.Find(x => x.AnswerText == answerName).AnswerId;
        }

        public void Update(Answer item)
        {
            throw new NotImplementedException();
        }

        public List<Answer> GetAnswers(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
