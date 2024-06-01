using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Endorsement
    {
        
        public int endorsementId { get; set; }
        public string endorserId { get; set; }
        public string recipientid { get; set; }
        public int skillId { get; set; }

       //navigation properties
        public virtual User Endorser { get; set; }
        public virtual User Recipient { get; set; }
    }
}
