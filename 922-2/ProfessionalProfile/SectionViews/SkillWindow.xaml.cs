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
using ProfessionalProfile.Profile_page;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionviewModels;

namespace ProfessionalProfile.SectionViews
{
    /// <summary>
    /// Interaction logic for SkillWindow.xaml
    /// </summary>
    public partial class SkillWindow : Window
    {
        private int userId;
        public SkillWindow(int userId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.userId = userId;
            SkillviewModel viewModel = new SkillviewModel(new SkillRepo(), userId);
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkExperienceWindow workExperienceWindow = new WorkExperienceWindow(userId);
            this.Hide();
            workExperienceWindow.Show();
        }
    }
}
