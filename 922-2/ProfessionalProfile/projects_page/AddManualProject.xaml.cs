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
    public partial class AddManualProject : Window
    {
        private ProjectRepo projectRepo = new ProjectRepo();

        private int currentUserId;

        private string TextName { get; set; }
        private string TextDescription { get; set; }
        private string TextTechnologies { get; set; }

        public AddManualProject(int userId)
        {
            InitializeComponent();

            currentUserId = userId;

            TextName = null;
            TextDescription = null;
            TextTechnologies = null;

            // Set the data context to this instance
            DataContext = this;
        }
        // Event handler for the "Save" button click
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Get the text entered in the text boxes
            string projectName = TextName;
            string projectDescription = TextDescription;
            string projectTechnologies = TextTechnologies;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(projectName) || string.IsNullOrWhiteSpace(projectDescription) || string.IsNullOrWhiteSpace(projectTechnologies))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Project project = new Project(0, projectName, projectDescription, projectTechnologies, currentUserId.ToString());

            // Save the project or perform further actions here
            projectRepo.Add(project);

            // For now, let's just close the window
            Close();
        }

        // Event handler for the "Cancel" button click
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving
            Close();
        }
    }
}
