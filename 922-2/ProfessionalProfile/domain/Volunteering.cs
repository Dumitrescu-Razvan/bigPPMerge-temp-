using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Volunteering
    {
        public int volunteeringId { get; set; }
        public int userId { get; set; }
        public string organisation { get; set; }
        public string role { get; set; }
        public string description { get; set; }

        //Navigation properties
        [JsonIgnore]
        public User? User { get; set; }
    }
}
