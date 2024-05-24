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
    public class AddEducationCommand : SectionCommandBase
    {
        private readonly EducationRepo educationRepo;
        private readonly EducationviewModel educationviewModel;
        private readonly int userId;

        public AddEducationCommand(EducationviewModel educationviewModel, EducationRepo educationRepo, int userId)
        {
            this.educationRepo = educationRepo;
            this.educationviewModel = educationviewModel;
            this.userId = userId;
            educationviewModel.PropertyChanged += OnviewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            double gpa;
            if (double.TryParse(educationviewModel.GPA, out gpa))
            {
                Education education = new Education(
                                                4,
                                                userId,
                                                educationviewModel.Degree,
                                                educationviewModel.Institution,
                                                educationviewModel.FieldOfStudy,
                                                educationviewModel.GraduationDate,
                                                gpa);

                try
                {
                    educationRepo.Add(education);
                    MessageBox.Show("Education added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return !string.IsNullOrEmpty(educationviewModel.Degree) &&
                !string.IsNullOrEmpty(educationviewModel.Institution) &&
                !string.IsNullOrEmpty(educationviewModel.FieldOfStudy) &&
                !string.IsNullOrEmpty(educationviewModel.GPA) &&
                base.CanExecute(parameter);
        }

        private void OnviewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(EducationviewModel.Degree) ||
                               e.PropertyName == nameof(EducationviewModel.Institution) ||
                                              e.PropertyName == nameof(EducationviewModel.FieldOfStudy) ||
                                                             e.PropertyName == nameof(EducationviewModel.GPA))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
