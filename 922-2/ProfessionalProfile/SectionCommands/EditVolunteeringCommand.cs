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
    public class EditVolunteeringCommand : SectionCommandBase
    {
        private readonly EditVolunteeringviewModel viewModel;
        private readonly VolunteeringRepo volunteeringRepo;
        private readonly int userId;
        private readonly int volunteeringId;

        public EditVolunteeringCommand(EditVolunteeringviewModel viewModel, VolunteeringRepo volunteeringRepo, int userId, int volunteeringId)
        {
            this.viewModel = viewModel;
            this.volunteeringRepo = volunteeringRepo;
            this.userId = userId;
            this.volunteeringId = volunteeringId;

            viewModel.PropertyChanged += OnviewModelPropertyChanged;
        }

        private void OnviewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.Organisation) ||
                               e.PropertyName == nameof(viewModel.Role) ||
                                             e.PropertyName == nameof(viewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            Volunteering updatedVolunteering = new Volunteering(
                                               volunteeringId,
                                              userId,
                                              viewModel.Organisation, viewModel.Role, viewModel.Description);

            try
            {
                volunteeringRepo.Update(updatedVolunteering);
                MessageBox.Show("Volunteering updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(viewModel.Organisation) &&
                !string.IsNullOrEmpty(viewModel.Role) &&
                !string.IsNullOrEmpty(viewModel.Description);
        }
    }
}
