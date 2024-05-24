using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionCommands;

namespace ProfessionalProfile.SectionviewModels
{
    public class EditWorkExperienceviewModel : SectionviewModelBase
    {
        public EditWorkExperienceviewModel(WorkExperienceRepo workExperienceRepo, int userId, int workExperienceId)
        {
            workExperience = workExperienceRepo.GetById(workExperienceId);
            JobTitle = workExperience.JobTitle;
            Company = workExperience.Company;
            Location = workExperience.Location;
            EmploymentPeriod = workExperience.EmploymentPeriod;
            Responsibilities = workExperience.Responsibilities;
            Achievements = workExperience.Achievements;
            Description = workExperience.Description;
            EditWorkExperienceButton = new EditWorkExperienceCommand(this, workExperienceRepo, userId, workExperienceId);
        }

        private WorkExperience workExperience;

        private string jobTitle;
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }

            set
            {
                jobTitle = value;

                OnPropertyChanged("JobTitle");
            }
        }

        private string company;
        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;

                OnPropertyChanged("Company");
            }
        }

        private string location;
        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;

                OnPropertyChanged("Location");
            }
        }

        private string employmentPeriod;
        public string EmploymentPeriod
        {
            get
            {
                return employmentPeriod;
            }

            set
            {
                employmentPeriod = value;

                OnPropertyChanged("EmploymentPeriod");
            }
        }

        private string responsibilities;
        public string Responsibilities
        {
            get
            {
                return responsibilities;
            }

            set
            {
                responsibilities = value;

                OnPropertyChanged("Responsibilities");
            }
        }

        private string achievements;
        public string Achievements
        {
            get
            {
                return achievements;
            }

            set
            {
                achievements = value;

                OnPropertyChanged("Achievements");
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;

                OnPropertyChanged("Description");
            }
        }

        public ICommand EditWorkExperienceButton { get; }
    }
}
