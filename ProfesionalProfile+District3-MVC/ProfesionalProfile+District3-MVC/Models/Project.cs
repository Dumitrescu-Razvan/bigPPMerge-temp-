﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Project
    {
        public int projectId { get; set;}
        public string projectName { get; set; }
        public string description { get; set; }
        public string technologies { get; set; }
        public string userId { get; set; }

        //Navigation properties
        public User User { get; set; }
    }
}
