using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionCommands;

namespace ProfessionalProfile.SectionviewModels
{
    public class WorkExperienceviewModel : SectionviewModelBase
    {
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

        public ICommand AddWorkExperienceButton { get; }

        public WorkExperienceviewModel(WorkExperienceRepo workExperienceRepo, int userId)
        {
            AddWorkExperienceButton = new AddWorkExperienceCommand(this, workExperienceRepo, userId);
        }
    }
}
