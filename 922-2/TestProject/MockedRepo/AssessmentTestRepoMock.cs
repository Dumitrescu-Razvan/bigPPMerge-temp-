using ProfessionalProfile.Domain;
using ProfessionalProfile.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockedRepo
{
    internal class AssessmentTestRepoMock : IAssessmentTestRepoInterface<AssessmentTest>
    {
        List<AssessmentTest> assessmentTests;

        public AssessmentTestRepoMock()
        {
            assessmentTests = new List<AssessmentTest>();
        }

        public void Add(AssessmentTest item)
        {
            assessmentTests.Add(item); 
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AssessmentTest> GetAll()
        {
            return this.assessmentTests;
        }

        public AssessmentTest GetById(int id)
        {
            for (int i = 0; i < assessmentTests.Count; i++)
            {
                if (assessmentTests[i].AssessmentTestId == id)
                {
                    return assessmentTests[i];
                }
            }
            return null;
        }

        public int GetIdByName(string testName)
        {
            for (int i = 0; i < assessmentTests.Count; i++)
            {
                if (assessmentTests[i].TestName == testName)
                {
                    return assessmentTests[i].AssessmentTestId;
                }
            }
            return -1;
        }

        public void Update(AssessmentTest item)
        {
            throw new NotImplementedException();
        }
    }
}
