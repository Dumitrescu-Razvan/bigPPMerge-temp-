using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    public class User
    {
        private int userId;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string phone;
        private string summary;
        private DateTime dateOfBirth;
        private bool darkTheme;
        private string address;
        private string websiteURL;
        private string picture;

        public User(int userId, string firstName, string lastName, string email, string password, string phone, string summary, DateTime dateOfBirth, bool darkTheme, string address, string websiteURL, string picture)
        {
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.summary = summary;
            this.dateOfBirth = dateOfBirth;
            this.darkTheme = darkTheme;
            this.address = address;
            this.websiteURL = websiteURL;
            this.picture = picture;
        }

        public int UserId
        {
            get { return this.userId; } set { this.userId = value; }
        }

        public string FirstName
        {
            get { return this.firstName; } set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
        public string Summary
        {
            get { return this.summary; }
            set { this.summary = value; }
        }
        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }
        public bool DarkTheme
        {
            get { return this.darkTheme; }
            set { this.darkTheme = value; }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public string WebsiteURL
        {
            get { return this.websiteURL; }
            set { this.websiteURL = value; }
        }

        public string Picture
        {
            get { return this.picture; }
            set { this.picture = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   userId == user.userId &&
                   firstName == user.firstName &&
                   lastName == user.lastName &&
                   email == user.email &&
                   password == user.password &&
                   phone == user.phone &&
                   summary == user.summary &&
                   dateOfBirth == user.dateOfBirth &&
                   darkTheme == user.darkTheme &&
                   address == user.address &&
                   picture == user.picture &&
                   Picture == user.Picture &&
                   UserId == user.UserId &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   Email == user.Email &&
                   Password == user.Password &&
                   Phone == user.Phone &&
                   Summary == user.Summary &&
                   DateOfBirth == user.DateOfBirth &&
                   DarkTheme == user.DarkTheme &&
                   Address == user.Address &&
                   WebsiteURL == user.WebsiteURL;
        }
    }
}
