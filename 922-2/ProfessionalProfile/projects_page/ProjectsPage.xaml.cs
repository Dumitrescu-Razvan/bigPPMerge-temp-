using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Projects_page
{
    public partial class ProjectsPage : Window
    {
        private ProjectRepo projectRepo = new ProjectRepo();
        private UserRepo userRepo = new UserRepo();
        private int currentUserId;
        private string ProjectName { get; set; }
        private string ProjectDescription { get; set; }
        private string ProjectTechnologies { get; set; }
        public List<Project> GitHubProjects { get; set; }
        public List<Project> ManualProjects { get; set; }

        public ProjectsPage(int userId, bool isVisiting = false)
        {
            InitializeComponent();

            User user = userRepo.GetById(userId);
            currentUserId = userId;

            if (isVisiting)
            {
                this.nameLabel.Content = user.FirstName + " " + user.LastName + "'s Portfolio";
            }
            else
            {
                this.nameLabel.Content = "My Portfolio";
            }
            List<Project> projects = projectRepo.GetByUserId(userId);

            ManualProjects = projects;

            // Set the data context to this instance
            DataContext = this;

            if (isVisiting)
            {
                addFromGitHub.Visibility = Visibility.Hidden;
                addManually.Visibility = Visibility.Hidden;
            }
        }
        private void AddFromGitHub_Click(object sender, RoutedEventArgs e)
        {
            // You can implement the logic to add projects from GitHub here
            // For now, let's just display a message box
            MessageBox.Show("Functionality to add projects from GitHub is not yet implemented.");
        }

        // Event handler for the "Add Manually" button click
        private void AddManually_Click(object sender, RoutedEventArgs e)
        {
            AddManualProject addManualProject = new AddManualProject(this.currentUserId);
            addManualProject.ShowDialog();

            ProjectsPage projectsPage = new ProjectsPage(this.currentUserId);
            projectsPage.Show();
            Close();
        }

        // Event handler for the "Go to Profile" button click
        private void GoToProfile_Click(object sender, RoutedEventArgs e)
        {
            // You can implement the logic to navigate to the profile page here
            // For now, let's just close the projects page
            Close();
        }
    }
}
