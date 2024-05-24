using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionCommands;

namespace ProfessionalProfile.SectionviewModels
{
    public class CertificateviewModel : SectionviewModelBase
    {
        private string certificateName;
        public string CertificateName
        {
            get => certificateName;
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

        private DateTime expirationDate = new DateTime(2024, 1, 2);
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

        public ICommand AddCertificateButton { get; }

        public CertificateviewModel(CertificateRepo certificateRepo, int userId, bool isLoggedIn)
        {
            AddCertificateButton = new AddCertificateCommand(this, certificateRepo, userId, isLoggedIn);
        }
    }
}
