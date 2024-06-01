using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Certificate
    {
        public int certificateId { get; set; }
        public string name { get; set; }
        public string issuedBy { get; set; }
        public string description { get; set; }
        public DateTime issuedDate { get; set; }
        public DateTime expirationDate { get; set; }
        public string userId { get; set; }

        // Navigation properties
        public virtual User User { get; set; }

       
    }
}
