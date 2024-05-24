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
    /// Interaction logic for NotificationsPage.xaml
    /// </summary>
    public partial class NotificationsPage : Window
    {
        private NotificationsService NotificationsService { get; }
        private SearchUsersService SearchUsersService { get; }
        private int userId;
        private User CurrentUser { get; set; }

        public NotificationsPage(int userId)
        {
            InitializeComponent();
            this.NotificationsService = new NotificationsService(new NotificationRepo());
            this.SearchUsersService = new SearchUsersService(new UserRepo());
            this.userId = userId;
            this.CurrentUser = SearchUsersService.GetUserById(userId);

            this.nameLabel.Content = "Hi, " + CurrentUser.FirstName + " " + CurrentUser.LastName;
            this.PopulateNotifications();
        }

        private void PopulateNotifications()
        {
            List<Notification> notifications = NotificationsService.GetNotifications(userId);

            foreach (Notification notification in notifications)
            {
                this.notificationsList.Items.Add(notification.Activity + " " + notification.Timestamp);
            }
        }
    }
}
