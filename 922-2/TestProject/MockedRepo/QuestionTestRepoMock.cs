using ProfessionalProfile.Domain;
using ProfessionalProfile.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockedRepo
{
    internal class QuestionTestRepoMock : IQuestionRepoInterface<Question>
    {
        List<Question> questions;
        
        public QuestionTestRepoMock()
        {
            questions = new List<Question>();
        }

        public void Add(Question item)
        {
            questions.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAll()
        {
            return this.questions;
        }

        public Question GetById(int id)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].QuestionId == id)
                {
                    return questions[i];
                }
            }
            return null;
        }

        public int GetIdByName(string questionName)
        {
            throw new NotImplementedException();
        }

        public void Update(Question item)
        {
            throw new NotImplementedException();
        }

        public int GetIdByNameAndAssessmentId(string questionName, int assessmentId)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].QuestionText == questionName)
                {
                    return questions[i].QuestionId;
                }
            }
            return -1;
        }

        public List<Question> GetAllByTestId(int assessmentId)
        {
            throw new NotImplementedException();
        }
    }
}
