using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Profile_page;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionExceptions;
using ProfessionalProfile.SectionviewModels;

namespace ProfessionalProfile.SectionCommands
{
    public class AddCertificateCommand : SectionCommandBase
    {
        private readonly CertificateRepo certificateRepo;
        private readonly CertificateviewModel certificateviewModel;
        private readonly int userId;
        private bool isLoggedIn;

        public AddCertificateCommand(SectionviewModels.CertificateviewModel certificateviewModel, CertificateRepo certificateRepo, int userId, bool isLoggedIn)
        {
            this.certificateRepo = certificateRepo;
            this.certificateviewModel = certificateviewModel;
            this.userId = userId;
            this.isLoggedIn = isLoggedIn;
            certificateviewModel.PropertyChanged += OnviewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            Certificate certificate = new Certificate(
                    4,
                    userId,
                    certificateviewModel.CertificateName,
                    certificateviewModel.IssuedBy,
                    certificateviewModel.Description,
                    certificateviewModel.IssuedDate,
                    certificateviewModel.ExpirationDate);

            try
            {
                certificateRepo.Add(certificate);
                MessageBox.Show("Certificate added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ProfilePage profilePage = new ProfilePage(userId, userId);
                profilePage.Show();
            }
            catch (CustomSectionException ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(certificateviewModel.CertificateName) &&
                !string.IsNullOrEmpty(certificateviewModel.IssuedBy) &&
                !string.IsNullOrEmpty(certificateviewModel.Description) &&
                base.CanExecute(parameter);
        }
        private void OnviewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CertificateviewModel.CertificateName) ||
                e.PropertyName == nameof(CertificateviewModel.IssuedBy) ||
                e.PropertyName == nameof(CertificateviewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
