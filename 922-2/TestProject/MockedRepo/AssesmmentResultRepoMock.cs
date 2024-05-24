using ProfessionalProfile.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;

namespace TestProject.MockedRepo
{
    internal class AssesmmentResultRepoMock : IAssessmentResultRepoInterface<AssessmentResult>
    {
        List<AssessmentResult> assessmentResults;
        
        public AssesmmentResultRepoMock()
        {
            assessmentResults = new List<AssessmentResult>();
        }

        public void Add(AssessmentResult item)
        {
            assessmentResults.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AssessmentResult> GetAll()
        {
            return this.assessmentResults;
        }

        public List<AssessmentResult> GetAssessmentResultsByUserId(int userId)
        {
            return assessmentResults.Where(x => x.UserId == userId).ToList();
        }

        public AssessmentResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AssessmentResult item)
        {
            throw new NotImplementedException();
        }
    }
}
