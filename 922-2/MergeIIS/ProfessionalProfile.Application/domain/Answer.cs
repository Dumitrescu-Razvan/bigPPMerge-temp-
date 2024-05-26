using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Answer
    {
        public int answerId { get; set; }
        public string answerText { get; set; }
        public int questionId { get; set; }
        public bool isCorrect { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual Question? Question { get; set; }
    }
}
