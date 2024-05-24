using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class BusinessCard
    {
        public int bcId { get; set;}
        public int userId { get; set; }
        public string summary { get; set; }
        public string uniqueUrl { get; set; }

        //Navigation properties
        [JsonIgnore]
        public User ?User { get; set; }
        [JsonIgnore]
        public ICollection<Skill> ?keySkills { get; set; }
    }
}
