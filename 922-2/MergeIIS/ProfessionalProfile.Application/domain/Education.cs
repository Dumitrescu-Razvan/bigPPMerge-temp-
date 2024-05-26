using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Education
    {
        public int educationId { get; set;}
        public int userId { get; set; }
        public string degree { get; set; }
        public string institution { get; set; }
        public string fieldOfStudy { get; set; }
        public DateTime graduationDate { get; set; }
        public double gPA;
        // Navigation properties
        [JsonIgnore]
        public virtual User ?User { get; set; }
    }
}
