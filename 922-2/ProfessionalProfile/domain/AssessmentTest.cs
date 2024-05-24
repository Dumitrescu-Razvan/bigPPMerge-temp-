using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class AssessmentTest
    {
        private int assessmentTestId;
        private string testName;
        private int userId;
        private string description;
        private int skillid;

        public AssessmentTest(int assestid, string testName, int userId, string description, int skillsAssessed)
        {
            this.assessmentTestId = assestid;
            this.testName = testName;
            this.userId = userId;
            this.description = description;
            this.skillid = skillsAssessed;
        }

        public int AssessmentTestId
        {
            get { return assessmentTestId; }
            set { assessmentTestId = value; }
        }

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Skillid
        {
            get { return skillid; }
            set { skillid = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is AssessmentTest test &&
                   assessmentTestId == test.assessmentTestId &&
                   testName == test.testName &&
                   userId == test.userId &&
                   description == test.description &&
                   skillid == test.skillid &&
                   AssessmentTestId == test.AssessmentTestId &&
                   TestName == test.TestName &&
                   UserId == test.UserId &&
                   Description == test.Description &&
                   Skillid == test.Skillid;
        }

        public override string ToString()
        {
            return testName + "\n" + description;
        }
    }
}
