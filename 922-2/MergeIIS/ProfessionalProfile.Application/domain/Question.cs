using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Question
    {
        public int questionId { get; set; } 
        public string questionText { get; set; }
        public int assesmentTestId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual AssessmentTest ?AssessmentTest { get; set; }
    }
}
