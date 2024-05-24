using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Answer
    {
        private int answerId;
        private string answerText;
        private int questionId;
        private bool isCorrect;

        public Answer(int answerId, string answerText, int questionId,  bool isCorrect)
        {
            this.answerId = answerId;
            this.questionId = questionId;
            this.answerText = answerText;
            this.isCorrect = isCorrect;
        }

        public int AnswerId
        {
            get { return answerId; }
            set { answerId = value; }
           }

        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; }
        }

        public string AnswerText
        {
            get { return answerText; }
            set { answerText = value; }
        }

        public bool IsCorrect
        {
            get { return isCorrect; } set { isCorrect = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Answer answer &&
                   answerId == answer.answerId &&
                   questionId == answer.questionId &&
                   answerText == answer.answerText &&
                   isCorrect == answer.isCorrect &&
                   AnswerId == answer.AnswerId &&
                   QuestionId == answer.QuestionId &&
                   AnswerText == answer.AnswerText &&
                   IsCorrect == answer.IsCorrect;
        }
    }
}
