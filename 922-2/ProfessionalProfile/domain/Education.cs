using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Education
    {
        private int educationId;
        private int userId;
        private string degree;
        private string institution;
        private string fieldOfStudy;
        private DateTime graduationDate;

        private double gPA;

        public Education(int educationId, int userId, string degree, string institution, string fieldOfStudy, DateTime graduationDate, double gpa)
        {
            this.educationId = educationId;
            this.degree = degree;
            this.institution = institution;
            this.fieldOfStudy = fieldOfStudy;
            this.graduationDate = graduationDate;
            this.userId = userId;
            this.gPA = gpa;
        }

        public int EducationId
        {
            get { return educationId; }
            set { educationId = value; }
        }

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        public string Institution
        {
            get { return institution; } set { institution = value; }
        }

        public string FieldOfStudy
        {
            get { return fieldOfStudy; }
            set { fieldOfStudy = value; }
        }

        public DateTime GraduationDate
        {
            get { return graduationDate; }
            set { graduationDate = value; }
        }

        public double GPA
        {
            get { return this.gPA; }
            set { this.gPA = value; }
        }

        public int UserId
        {
             get { return this.userId; } set { this.userId = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Education education &&
                   educationId == education.educationId &&
                   degree == education.degree &&
                   institution == education.institution &&
                   fieldOfStudy == education.fieldOfStudy &&
                   graduationDate == education.graduationDate &&
                   GPA == education.GPA &&
                   userId == education.userId &&
                   UserId == education.UserId &&
                   EducationId == education.EducationId &&
                   Degree == education.Degree &&
                   Institution == education.Institution &&
                   FieldOfStudy == education.FieldOfStudy &&
                   GraduationDate == education.GraduationDate;
        }

        public override string ToString()
        {
            return institution + "\n" + degree + "\n" + fieldOfStudy + "\n" + graduationDate;
        }
    }
}
