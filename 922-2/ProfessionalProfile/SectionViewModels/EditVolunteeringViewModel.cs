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
    public class EditVolunteeringviewModel : SectionviewModelBase
    {
        public EditVolunteeringviewModel(VolunteeringRepo volunteeringRepo, int userId, int volunteeringId)
        {
            volunteering = volunteeringRepo.GetById(volunteeringId);
            Organisation = volunteering.Organisation;
            Role = volunteering.Role;
            Description = volunteering.Description;
            EditVolunteeringButton = new EditVolunteeringCommand(this, volunteeringRepo, userId, volunteeringId);
        }
        private Volunteering volunteering;

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

        public ICommand EditVolunteeringButton { get; }
    }
}
