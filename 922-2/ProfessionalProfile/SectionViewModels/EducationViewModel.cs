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
    public class EducationviewModel : SectionviewModelBase
    {
        private string degree;
        public string Degree
        {
            get
            {
                return degree;
            }

            set
            {
                degree = value;

                OnPropertyChanged("Degree");
            }
        }

        private string institution;
        public string Institution
        {
            get
            {
                return institution;
            }

            set
            {
                institution = value;

                OnPropertyChanged("Institution");
            }
        }

        private string fieldOfStudy;
        public string FieldOfStudy
        {
            get
            {
                return fieldOfStudy;
            }

            set
            {
                fieldOfStudy = value;

                OnPropertyChanged("FieldOfStudy");
            }
        }

        private DateTime graduationDate = new DateTime(2024, 1, 1);
        public DateTime GraduationDate
        {
            get
            {
                return graduationDate;
            }

            set
            {
                graduationDate = value;

                OnPropertyChanged("GraduationDate");
            }
        }

        private string gpa;
        public string GPA
        {
            get
            {
                return gpa;
            }

            set
            {
                gpa = value;

                OnPropertyChanged("GPA");
            }
        }

        public ICommand AddEducationButton { get; }

        public EducationviewModel(EducationRepo educationRepo, int userId)
        {
            AddEducationButton = new AddEducationCommand(this, educationRepo, userId);
        }
    }
}
