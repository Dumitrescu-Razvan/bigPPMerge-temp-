using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Project
    {
        public int projectId { get; set;}
        public string projectName { get; set; }
        public string description { get; set; }
        public string technologies { get; set; }
        public int userId { get; set; }

        //Navigation properties
        [JsonIgnore]
        public User? User { get; set; }
    }
}
