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
    public class VolunteeringviewModel : SectionviewModelBase
    {
        private string organisation;
        public string Organisation
        {
            get
            {
                return organisation;
            }

            set
            {
                organisation = value;

                OnPropertyChanged("Organisation");
            }
        }

        private string role;
        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;

                OnPropertyChanged("Role");
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

        public ICommand AddVolunteeringButton { get; }

        public VolunteeringviewModel(VolunteeringRepo volunteeringRepo, int userId)
        {
            AddVolunteeringButton = new AddVolunteeringCommand(volunteeringRepo, this, userId);
        }
    }
}
