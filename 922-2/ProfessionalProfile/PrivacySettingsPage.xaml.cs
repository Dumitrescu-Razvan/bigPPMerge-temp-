using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProfessionalProfile.Business;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.View
{
    /// <summary>
    /// Interaction logic for PrivacySettingsPage.xaml
    /// </summary>
    public partial class PrivacySettingsPage : Window
    {
        public int UserId;

        private SearchUsersService SearchUsersService { get; set; }
        private PrivacyService PrivacyService { get; set; }

        public PrivacySettingsPage(int userId)
        {
            InitializeComponent();
            this.UserId = userId;
            SearchUsersService = new SearchUsersService(new UserRepo());
            PrivacyService = new PrivacyService();

            LoadPrivacy();
        }

        public void LoadPrivacy()
        {
            User currentUser = SearchUsersService.GetUserById(UserId);
            Privacy privacy = PrivacyService.GetPrivacy(currentUser.UserId);

            this.helloLabel.Content = "Hello " + currentUser.FirstName + " " + currentUser.LastName;

            if (privacy.CanViewEducation)
            {
                educationPublicCheckBox.IsChecked = true;
            }
            else
            {
                educationPrivateCheckBox.IsChecked = true;
            }

            if (privacy.CanViewWorkExperience)
            {
                workExperiencePublicCheckBox.IsChecked = true;
            }
            else
            {
                workExperiencePrivateCheckBox.IsChecked = true;
            }

            if (privacy.CanViewSkills)
            {
                skillsPublicCheckBox.IsChecked = true;
            }
            else
            {
                skillsPrivateCheckBox.IsChecked = true;
            }

            if (privacy.CanViewCertificates)
            {
                certificationsPublicCheckBox.IsChecked = true;
            }
            else
            {
                certificationsPrivateCheckBox.IsChecked = true;
            }

            if (privacy.CanViewVolunteering)
            {
                volunteeringPublicCheckBox.IsChecked = true;
            }
            else
            {
                volunteeringPrivateCheckBox.IsChecked = true;
            }

            if (privacy.CanViewProjects)
            {
                projectsPublicCheckBox.IsChecked = true;
            }
            else
            {
                projectsPrivateCheckBox.IsChecked = true;
            }
        }

        private void EducationPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            educationPrivateCheckBox.IsChecked = false;
        }

        private void EducationPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            educationPublicCheckBox.IsChecked = false;
        }

        private void WorkExperiencePublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            workExperiencePrivateCheckBox.IsChecked = false;
        }

        private void WorkExperiencePrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            workExperiencePublicCheckBox.IsChecked = false;
        }

        private void VolunteeringPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            volunteeringPrivateCheckBox.IsChecked = false;
        }

        private void VolunteeringPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            volunteeringPublicCheckBox.IsChecked = false;
        }

        private void CertificationsPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            certificationsPrivateCheckBox.IsChecked = false;
        }

        private void CertificationsPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            certificationsPublicCheckBox.IsChecked = false;
        }

        private void SkillsPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            skillsPrivateCheckBox.IsChecked = false;
        }

        private void SkillsPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            skillsPublicCheckBox.IsChecked = false;
        }

        private void ProjectsPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            projectsPrivateCheckBox.IsChecked = false;
        }

        private void ProjectsPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            projectsPublicCheckBox.IsChecked = false;
        }

        private void ChangePrivacyButton_Click(object sender, RoutedEventArgs e)
        {
            bool canViewEducation = IsPublic(educationPublicCheckBox, educationPrivateCheckBox);
            bool canViewWorkExperience = IsPublic(workExperiencePublicCheckBox, workExperiencePrivateCheckBox);
            bool canViewSkills = IsPublic(skillsPublicCheckBox, skillsPrivateCheckBox);
            bool canViewCertificates = IsPublic(certificationsPublicCheckBox, certificationsPrivateCheckBox);
            bool canViewVolunteering = IsPublic(volunteeringPublicCheckBox, volunteeringPrivateCheckBox);
            bool canViewProjects = IsPublic(projectsPublicCheckBox, projectsPrivateCheckBox);

            Privacy privacy = new Privacy(UserId, canViewEducation, canViewWorkExperience, canViewSkills, canViewCertificates, canViewVolunteering, canViewProjects);
            PrivacyService.UpdatePrivacy(privacy);

            this.updateSuccessLabel.Content = "Privacy settings updated successfully!";
        }

        private bool IsPublic(CheckBox publicCheckBox, CheckBox privateCheckBox)
        {
            return publicCheckBox.IsChecked == true && privateCheckBox.IsChecked == false;
        }
    }
}
