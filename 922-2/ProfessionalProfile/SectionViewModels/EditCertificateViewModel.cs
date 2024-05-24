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
    internal class EditCertificateviewModel : SectionviewModelBase
    {
        public EditCertificateviewModel(CertificateRepo certificateRepo, int userId, int certificateId)
        {
            certificate = certificateRepo.GetById(certificateId);
            CertificateName = certificate.Name;
            IssuedBy = certificate.IssuedBy;
            Description = certificate.Description;
            IssuedDate = certificate.IssuedDate;
            ExpirationDate = certificate.ExpirationDate;
            EditCertificateButton = new EditCertificateCommand(this, certificateRepo, userId, certificateId);
        }

        private Certificate certificate;

        private string certificateName;
        public string CertificateName
        {
            get
            {
                return certificateName;
            }

            set
            {
                certificateName = value;

                OnPropertyChanged("CertificateName");
            }
        }

        private string issuedBy;
        public string IssuedBy
        {
            get
            {
                return issuedBy;
            }

            set
            {
                issuedBy = value;

                OnPropertyChanged("IssuedBy");
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

        private DateTime issuedDate = new DateTime(2024, 1, 1);
        public DateTime IssuedDate
        {
            get
            {
                return issuedDate;
            }

            set
            {
                issuedDate = value;

                OnPropertyChanged("IssuedDate");
            }
        }

        private DateTime expirationDate = new DateTime(2024, 1, 20);
        public DateTime ExpirationDate
        {
            get
            {
                return expirationDate;
            }

            set
            {
                expirationDate = value;

                OnPropertyChanged("ExpirationDate");
            }
        }
        public ICommand EditCertificateButton { get; }
    }
}
