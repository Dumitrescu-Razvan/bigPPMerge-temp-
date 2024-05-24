using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Privacy
    {
        public int UserId { get; set; }
        public bool CanViewEducation { get; set; }
        public bool CanViewWorkExperience { get; set; }
        public bool CanViewSkills { get; set; }
        public bool CanViewProjects { get; set; }
        public bool CanViewCertificates { get; set; }
        public bool CanViewVolunteering { get; set; }

        public Privacy(int userId, bool canViewEducation, bool canViewWorkExperience, bool canViewSkills, bool canViewProjects, bool canViewCertificates, bool canViewVolunteering)
        {
            this.UserId = userId;
            this.CanViewEducation = canViewEducation;
            this.CanViewWorkExperience = canViewWorkExperience;
            this.CanViewSkills = canViewSkills;
            this.CanViewProjects = canViewProjects;
            this.CanViewCertificates = canViewCertificates;
            this.CanViewVolunteering = canViewVolunteering;
        }
    }
}
