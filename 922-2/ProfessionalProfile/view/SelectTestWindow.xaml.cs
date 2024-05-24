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
    /// Interaction logic for SelectTestWindow.xaml
    /// </summary>
    public partial class SelectTestWindow : Window
    {
        private SelectTestService SelectTestService { get; }
        private AssessmentResultsService AssessmentResultsService { get; }
        private int UserId { get; set; }

        public SelectTestWindow(int userId)
        {
            InitializeComponent();
            this.UserId = userId;
            SelectTestService = new SelectTestService();
            AssessmentResultRepo assessmentResultRepo = new AssessmentResultRepo();
            AssessmentTestRepo assessmentTestRepo = new AssessmentTestRepo();
            AssessmentResultsService = new AssessmentResultsService(assessmentResultRepo, assessmentTestRepo);
            PopulateTestsNames();
            LoadPreviousResults();
        }

        public void LoadPreviousResults()
        {
            this.previousResultsListBox.Items.Clear();

            List<AssessmentResult> assessmentResults = this.AssessmentResultsService.GetResultsByUserId(this.UserId);

            if (assessmentResults.Count == 0)
            {
                this.previousResultsListBox.Items.Add("No previous results");
                return;
            }

            this.previousResultsListBox.Items.Add("Skill - Score - Date");

            foreach (AssessmentResult result in assessmentResults)
            {
                AssessmentTest test = this.AssessmentResultsService.GetTestById(result.AssessmentTestId);
                this.previousResultsListBox.Items.Add(test.TestName + " - " + result.Score + " - " + result.TestDate.ToShortDateString());
            }
        }

        private void PopulateTestsNames()
        {
            List<AssessmentTest> tests = SelectTestService.GetAllAssessmentTests();

            foreach (AssessmentTest test in tests)
            {
                assessmentNames.Items.Add(test.TestName);
            }
        }

        private void AssessmentNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = (string)assessmentNames.SelectedItem;

            if (selectedItem == null)
            {
                return;
            }

            AssessmentTest test = SelectTestService.GetAssessmentByName(selectedItem);
            Skill skill = SelectTestService.GetSkillById(test.Skillid);

            this.assessmentDescriptionBox.Text = test.Description;
            this.skillTestedLabel.Content = "Skill tested: " + skill.Name;
        }

        private void SelectTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (assessmentNames.SelectedItem == null)
            {
                MessageBox.Show("Please select a test");
                return;
            }

            string testName = (string)assessmentNames.SelectedItem;

            AssessmentTest test = SelectTestService.GetAssessmentByName(testName);

            // TODO: Open the test window
            TakeTestWindow takeTestWindow = new TakeTestWindow(test.AssessmentTestId, this.UserId);
            takeTestWindow.Show();
            this.Close();
        }
    }
}
