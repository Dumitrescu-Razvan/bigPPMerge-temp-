using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Skill
    {
        public int skillId { get; set;}
        public string name { get; set; }


        //navigation property
        [JsonIgnore]
        public ICollection<Endorsement>? endorsements { get; set;}
        
    }
}
