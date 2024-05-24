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
    public class AddWorkExperienceCommand : SectionCommandBase
    {
        private readonly WorkExperienceRepo workExperienceRepo;
        private readonly WorkExperienceviewModel workExperienceviewModel;
        private readonly int userId;

        public AddWorkExperienceCommand(WorkExperienceviewModel workExperienceviewModel, WorkExperienceRepo workExperienceRepo, int userId)
        {
            this.workExperienceRepo = workExperienceRepo;
            this.workExperienceviewModel = workExperienceviewModel;
            this.userId = userId;
            workExperienceviewModel.PropertyChanged += OnviewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            WorkExperience workExperience = new WorkExperience(4, userId, workExperienceviewModel.JobTitle, workExperienceviewModel.Company, workExperienceviewModel.Location, workExperienceviewModel.EmploymentPeriod, workExperienceviewModel.Responsibilities, workExperienceviewModel.Achievements, workExperienceviewModel.Description);

            try
            {
                workExperienceRepo.Add(workExperience);
                MessageBox.Show("Work Experience added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(workExperienceviewModel.JobTitle) &&
                !string.IsNullOrEmpty(workExperienceviewModel.Company) &&
                !string.IsNullOrEmpty(workExperienceviewModel.Location) &&
                !string.IsNullOrEmpty(workExperienceviewModel.EmploymentPeriod) &&
                !string.IsNullOrEmpty(workExperienceviewModel.Responsibilities) &&
                !string.IsNullOrEmpty(workExperienceviewModel.Achievements) &&
                !string.IsNullOrEmpty(workExperienceviewModel.Description) &&
                base.CanExecute(parameter);
        }

        private void OnviewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(WorkExperienceviewModel.JobTitle) ||
                               e.PropertyName == nameof(WorkExperienceviewModel.Company) ||
                                              e.PropertyName == nameof(WorkExperienceviewModel.Location) ||
                                                             e.PropertyName == nameof(WorkExperienceviewModel.EmploymentPeriod) ||
                                                                            e.PropertyName == nameof(WorkExperienceviewModel.Responsibilities) ||
                                                                                           e.PropertyName == nameof(WorkExperienceviewModel.Achievements) ||
                                                                                                          e.PropertyName == nameof(WorkExperienceviewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
