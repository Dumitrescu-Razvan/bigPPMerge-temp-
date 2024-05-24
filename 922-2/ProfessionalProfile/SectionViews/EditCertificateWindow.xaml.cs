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
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionviewModels;

namespace ProfessionalProfile.SectionViews
{
    /// <summary>
    /// Interaction logic for EditCertificateWindow.xaml
    /// </summary>
    public partial class EditCertificateWindow : Window
    {
        public EditCertificateWindow(int userId, int certificateId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            EditCertificateviewModel viewModel = new EditCertificateviewModel(new CertificateRepo(), userId, certificateId);
            DataContext = viewModel;
        }

        // press cancel button to close the window
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
