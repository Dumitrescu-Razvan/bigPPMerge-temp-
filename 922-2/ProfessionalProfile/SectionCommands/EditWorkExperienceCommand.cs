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
    public class EditWorkExperienceCommand : SectionCommandBase
    {
        private readonly EditWorkExperienceviewModel viewModel;
        private readonly WorkExperienceRepo workExperienceRepo;
        private readonly int userId;
        private readonly int workExperienceId;

        public EditWorkExperienceCommand(EditWorkExperienceviewModel viewModel, WorkExperienceRepo workExperienceRepo, int userId, int workExperienceId)
        {
            this.viewModel = viewModel;
            this.workExperienceRepo = workExperienceRepo;
            this.userId = userId;
            this.workExperienceId = workExperienceId;

            viewModel.PropertyChanged += OnviewModelPropertyChanged;
        }

        private void OnviewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.JobTitle) ||
                               e.PropertyName == nameof(viewModel.Company) ||
                                              e.PropertyName == nameof(viewModel.Location) ||
                                                             e.PropertyName == nameof(viewModel.EmploymentPeriod) ||
                                                                            e.PropertyName == nameof(viewModel.Responsibilities) ||
                                                                                           e.PropertyName == nameof(viewModel.Achievements) ||
                                                                                                          e.PropertyName == nameof(viewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            WorkExperience updatedWorkExperience = new WorkExperience(
                               workExperienceId,
                                              userId,
                                                             viewModel.JobTitle,
                                                                            viewModel.Company,
                                                                                           viewModel.Location,
                                                                                                          viewModel.EmploymentPeriod,
                                                                                                                         viewModel.Responsibilities,
                                                                                                                                        viewModel.Achievements,
                                                                                                                                                       viewModel.Description);

            try
            {
                workExperienceRepo.Update(updatedWorkExperience);
                MessageBox.Show("Work Experience updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(viewModel.JobTitle) &&
                !string.IsNullOrEmpty(viewModel.Company) &&
                !string.IsNullOrEmpty(viewModel.Location) &&
                !string.IsNullOrEmpty(viewModel.EmploymentPeriod) &&
                !string.IsNullOrEmpty(viewModel.Responsibilities) &&
                !string.IsNullOrEmpty(viewModel.Achievements) &&
                !string.IsNullOrEmpty(viewModel.Description) &&
                base.CanExecute(parameter);
        }
    }
}
