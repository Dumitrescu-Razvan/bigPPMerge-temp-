using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Project
    {
        private int projectId;
        private string projectName;
        private string description;
        private string technologies;
        private string userId;

        public Project(int projectId, string projectName, string description, string technologies, string userId)
        {
            this.projectId = projectId;
            this.projectName = projectName;
            this.description = description;
            this.technologies = technologies;
            this.userId = userId;
        }

        public int ProjectId
        {
            get { return this.projectId; }
            set { this.projectId = value; }
        }

        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string Technologies
        {
            get { return this.technologies; }
            set { this.technologies = value; }
        }

        public string UserId
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Project project &&
                   projectId == project.projectId &&
                   projectName == project.projectName &&
                   description == project.description &&
                   technologies == project.technologies &&
                   userId == project.userId &&
                   ProjectId == project.ProjectId &&
                   ProjectName == project.ProjectName &&
                   Description == project.Description;
        }

        public override string ToString()
        {
            return projectName + "\n" + description + "\n" + technologies;
        }
    }
}
