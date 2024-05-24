using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Question
    {
        private int questionId;
        private string questionText;
        private int assesmentTestId;

        public Question(int questionId, string questionText, int assesmentTestId)
        {
            this.questionId = questionId;
            this.questionText = questionText;
            this.assesmentTestId = assesmentTestId;
        }

        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; }
        }

        public int AssesmentTestId
        {
            get { return assesmentTestId; }
            set { assesmentTestId = value; }
        }

        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Question question &&
                   questionId == question.questionId &&
                   questionText == question.questionText &&
                   assesmentTestId == question.assesmentTestId &&
                   QuestionId == question.QuestionId &&
                   AssesmentTestId == question.AssesmentTestId &&
                   QuestionText == question.QuestionText;
        }

        public override string ToString()
        {
            return questionText;
        }
    }
}
