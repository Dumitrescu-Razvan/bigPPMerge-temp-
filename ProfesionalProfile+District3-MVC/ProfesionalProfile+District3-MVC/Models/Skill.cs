using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Skill
    {
        public int skillId { get; set;}
        public string name { get; set; }

        //navigation property
        public ICollection<Endorsement> endorsements { get; set;}
        
    }
}
