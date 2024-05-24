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
    internal class EditCertificateCommand : SectionCommandBase
    {
        private readonly CertificateRepo certificateRepo;
        private readonly EditCertificateviewModel certificateviewModel;
        private readonly int certificateId;
        private readonly int userId;

        public EditCertificateCommand(EditCertificateviewModel certificateviewModel, CertificateRepo certificateRepo, int userId, int certificateId)
        {
            this.certificateRepo = certificateRepo;
            this.certificateviewModel = certificateviewModel;
            this.certificateId = certificateId;
            this.userId = userId;
            certificateviewModel.PropertyChanged += OnviewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            Certificate updatedCertificate = new Certificate(
                               certificateId,
                                              userId,
                                                             certificateviewModel.CertificateName,
                                                                            certificateviewModel.IssuedBy,
                                                                                           certificateviewModel.Description,
                                                                                                          certificateviewModel.IssuedDate,
                                                                                                                         certificateviewModel.ExpirationDate);

            try
            {
                certificateRepo.Update(updatedCertificate);
                MessageBox.Show("Certificate updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
