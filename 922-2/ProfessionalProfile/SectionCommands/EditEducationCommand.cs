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
    public class EditEducationCommand : SectionCommandBase
    {
        private readonly EditEducationviewModel viewModel;
        private readonly EducationRepo educationRepo;
        private readonly int userId;
        private readonly int educationId;

        public EditEducationCommand(EditEducationviewModel viewModel, EducationRepo educationRepo, int userId, int educationId)
        {
            this.viewModel = viewModel;
            this.educationRepo = educationRepo;
            this.userId = userId;
            this.educationId = educationId;
            viewModel.PropertyChanged += OnviewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            double gpa;
            if (double.TryParse(viewModel.GPA, out gpa))
            {
                Education updatedEducation = new Education(
                                   educationId,
                                                  userId,
                                                                 viewModel.Degree,
                                                                                viewModel.Institution,
                                                                                               viewModel.FieldOfStudy,
                                                                                                              viewModel.GraduationDate,
                                                                                                                             gpa);
                try
                {
                    educationRepo.Update(updatedEducation);
                    MessageBox.Show("Education updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (CustomSectionException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid GPA value. Please enter a numerical value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(viewModel.Degree) &&
                !string.IsNullOrEmpty(viewModel.Institution) &&
                !string.IsNullOrEmpty(viewModel.FieldOfStudy) &&
                !string.IsNullOrEmpty(viewModel.GPA) &&
                base.CanExecute(parameter);
        }

        private void OnviewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.Degree) ||
                               e.PropertyName == nameof(viewModel.Institution) ||
                                              e.PropertyName == nameof(viewModel.FieldOfStudy) ||
                                                             e.PropertyName == nameof(viewModel.GPA))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
