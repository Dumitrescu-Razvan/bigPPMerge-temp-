﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Privacy
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public bool CanViewEducation { get; set; }
        public bool CanViewWorkExperience { get; set; }
        public bool CanViewSkills { get; set; }
        public bool CanViewProjects { get; set; }
        public bool CanViewCertificates { get; set; }
        public bool CanViewVolunteering { get; set; }

        //navigation properties
        [JsonIgnore]
       public virtual User? User { get; set; }
      
    }
}
