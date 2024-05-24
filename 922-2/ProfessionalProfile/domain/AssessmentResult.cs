using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class AssessmentResult
    {
        private int assesmentResultId;
        private int assesmentTestId;
        private int score;
        private int userId;
        private DateTime testDate;

        public AssessmentResult(int assesmentResultId, int assesmenttid, int userId, int score,  DateTime testDate)
        {
            this.assesmentResultId = assesmentResultId;
            this.assesmentTestId = assesmenttid;
            this.score = score;
            this.userId = userId;
            this.testDate = testDate;
        }

        public int AssessmentResultId
        {
            get { return assesmentResultId; }
            set { assesmentResultId = value; }
        }

        public int AssessmentTestId
        {
            get { return assesmentTestId; }
            set { assesmentTestId = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public DateTime TestDate
        {
            get { return this.testDate; } set { this.testDate = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is AssessmentResult result &&
                    assesmentResultId == result.assesmentResultId &&
                    assesmentTestId == result.assesmentTestId &&
                    score == result.score &&
                    userId == result.userId &&
                    testDate == result.testDate &&
                    AssessmentResultId == result.AssessmentResultId &&
                    AssessmentTestId == result.AssessmentTestId &&
                    Score == result.Score &&
                    UserId == result.UserId &&
                    TestDate == result.TestDate;
        }

        public override string ToString()
        {
            return score.ToString();
        }
    }
}
