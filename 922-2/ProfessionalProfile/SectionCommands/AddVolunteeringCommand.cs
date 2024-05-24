using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionExceptions;
using ProfessionalProfile.SectionviewModels;

namespace ProfessionalProfile.SectionCommands
{
    public class AddVolunteeringCommand : SectionCommandBase
    {
        private readonly VolunteeringRepo volunteeringRepo;
        private readonly VolunteeringviewModel volunteeringviewModel;
        private readonly int userId;

        public AddVolunteeringCommand(VolunteeringRepo volunteeringRepo, VolunteeringviewModel volunteeringviewModel, int userId)
        {
            this.volunteeringRepo = volunteeringRepo;
            this.volunteeringviewModel = volunteeringviewModel;
            this.userId = userId;
            volunteeringviewModel.PropertyChanged += OnviewModelPropertyChanged;
        }
        public override void Execute(object parameter)
        {
            Volunteering volunteering = new Volunteering(4, userId, volunteeringviewModel.Organisation, volunteeringviewModel.Role, volunteeringviewModel.Description);

            volunteeringRepo.Add(volunteering);
            MessageBox.Show("Volunteering added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(volunteeringviewModel.Organisation) &&
                !string.IsNullOrEmpty(volunteeringviewModel.Role) &&
                !string.IsNullOrEmpty(volunteeringviewModel.Description) &&
                base.CanExecute(parameter);
        }

        private void OnviewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(VolunteeringviewModel.Organisation) ||
                               e.PropertyName == nameof(VolunteeringviewModel.Role) ||
                                              e.PropertyName == nameof(VolunteeringviewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
