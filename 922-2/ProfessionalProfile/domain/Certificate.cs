using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class Certificate
    {
        private int certificateId;
        private string name;
        private string issuedBy;
        private string description;
        private DateTime issuedDate;
        private DateTime expirationDate;
        private int userId;

        public Certificate(int certificateId, int userId, string name, string issuedBy, string description, DateTime issuedDate, DateTime expirationDate)
        {
            this.certificateId = certificateId;
            this.name = name;
            this.issuedBy = issuedBy;
            this.description = description;
            this.issuedDate = issuedDate;
            this.expirationDate = expirationDate;
            this.userId = userId;
        }

        public int CertificateId
        {
            get { return this.certificateId; }
            set { this.certificateId = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string IssuedBy
        {
            get { return this.issuedBy; }
            set { this.issuedBy = value; }
        }

        public DateTime IssuedDate
        {
            get { return this.issuedDate; }
            set { this.issuedDate = value; }
        }

        public DateTime ExpirationDate
        {
            get { return this.expirationDate; }
            set { this.expirationDate = value; }
        }

        public int UserId
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Certificate certification &&
                   certificateId == certification.certificateId &&
                   name == certification.name &&
                   issuedBy == certification.issuedBy &&
                   description == certification.description &&
                   issuedDate == certification.issuedDate &&
                   expirationDate == certification.expirationDate &&
                   userId == certification.userId &&
                   CertificateId == certification.CertificateId &&
                   Name == certification.Name &&
                   IssuedBy == certification.IssuedBy &&
                   Description == certification.Description &&
                   IssuedDate == certification.IssuedDate &&
                   ExpirationDate == certification.ExpirationDate &&
                   UserId == certification.UserId;
        }

        public override string ToString()
        {
            return name + "\n" + description + "\n" + issuedBy + "\n" + issuedDate + "\n" + expirationDate;
        }
    }
}
