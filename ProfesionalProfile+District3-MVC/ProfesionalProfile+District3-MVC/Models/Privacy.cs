﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Privacy
    {
        [Key]
        public int Id { get; set; }
        public string userId { get; set; }
        public bool CanViewEducation { get; set; }
        public bool CanViewWorkExperience { get; set; }
        public bool CanViewSkills { get; set; }
        public bool CanViewProjects { get; set; }
        public bool CanViewCertificates { get; set; }
        public bool CanViewVolunteering { get; set; }

        //navigation properties
       public virtual User User { get; set; }
      
    }
}
