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
    public class AssessmentTestRepoMock : IAssessmentTestRepoInterface<AssessmentTest>
    {
        private List<AssessmentTest> assessmentTests;

        public AssessmentTestRepoMock()
        {
            // IsRead connection string from app.config
            this.assessmentTests = new List<AssessmentTest>();
        }

        public void Add(AssessmentTest item)
        {
            this.assessmentTests.Add(item);
        }

        public int GetIdByName(string testName)
        {
            int id = 0;
            foreach (AssessmentTest test in assessmentTests)
            {
                if (test.TestName == testName)
                {
                    id = test.AssessmentTestId;
                }
            }
            return id;
        }

        public List<AssessmentTest> GetAll()
        {
           return assessmentTests;
        }

        public void Delete(int id)
        {
        }

        public AssessmentTest GetById(int id)
        {
            AssessmentTest assessmentTest = null;
            foreach (AssessmentTest test in assessmentTests)
            {
                if (test.AssessmentTestId == id)
                {
                    assessmentTest = test;
                }
            }

            return assessmentTest;
        }

        public void Update(AssessmentTest item)
        {
        }
    }
}
