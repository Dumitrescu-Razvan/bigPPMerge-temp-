using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class WorkExperience
    {
        private int workId;
        private int userId;
        private string jobTitle;
        private string company;
        private string location;
        private string employmentPeriod;
        private string responsibilities;
        private string achievements;
        private string description;

        public WorkExperience(int workId, int userId, string jobTitle, string company, string location, string employmentPeriod, string responsibilities, string achievements, string description)
        {
            this.workId = workId;
            this.jobTitle = jobTitle;
            this.company = company;
            this.location = location;
            this.employmentPeriod = employmentPeriod;
            this.responsibilities = responsibilities;
            this.achievements = achievements;
            this.description = description;
            this.userId = userId;
        }

        public int WorkId
        {
            get { return workId; }
            set { workId = value; }
        }

        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string EmploymentPeriod
        {
            get { return employmentPeriod; }
            set { employmentPeriod = value; }
        }

        public string Achievements
        {
            get { return achievements; }
            set { achievements = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int UserId
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public string Responsibilities
        {
            get { return responsibilities; }
            set { responsibilities = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is WorkExperience experience &&
                   workId == experience.workId &&
                   jobTitle == experience.jobTitle &&
                   company == experience.company &&
                   location == experience.location &&
                   employmentPeriod == experience.employmentPeriod &&
                   responsibilities == experience.responsibilities &&
                   achievements == experience.achievements &&
                   description == experience.description &&
                   userId == experience.userId &&
                   UserId == experience.UserId &&
                   WorkId == experience.WorkId &&
                   JobTitle == experience.JobTitle &&
                   Company == experience.Company &&
                   Location == experience.Location &&
                   EmploymentPeriod == experience.EmploymentPeriod &&
                   Achievements == experience.Achievements &&
                   Description == experience.Description;
        }

        public override string ToString()
        {
            return jobTitle + "\n" + company + "\n" + location + "\n" + employmentPeriod + "\n" +
                responsibilities + "\n" + description + "\n" + achievements;
        }
    }
}
