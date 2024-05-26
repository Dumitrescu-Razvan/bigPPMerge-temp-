using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Certificate
    {
        public int certificateId { get; set; }
        public string name { get; set; }
        public string issuedBy { get; set; }
        public string description { get; set; }
        public DateTime issuedDate { get; set; }
        public DateTime expirationDate { get; set; }
        public int userId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual User? User { get; set; }


    }
}
