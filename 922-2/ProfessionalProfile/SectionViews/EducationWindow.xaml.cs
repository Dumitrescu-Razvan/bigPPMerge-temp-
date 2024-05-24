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
    /// Interaction logic for EducationWindow.xaml
    /// </summary>
    public partial class EducationWindow : Window
    {
        private int userId;
        public EducationWindow(int userId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.userId = userId;
            EducationviewModel viewModel = new EducationviewModel(new EducationRepo(), userId);
            DataContext = viewModel;
        }

        private void OpenWorkExperienceWindow(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage(userId, userId);
            this.Visibility = Visibility.Hidden;
            profilePage.Show();
        }
    }
}
