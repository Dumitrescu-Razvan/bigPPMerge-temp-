using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ProfessionalProfile.Profile_page;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.View
{
    /// <summary>
    /// Interaction logic for SearchUserPage.xaml
    /// </summary>
    ///
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ListItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class SearchUserPage : Window
    {
        private SearchUsersService SearchUsersService { get; }
        private NotificationsService NotificationsService { get; }
        private int userId;

        public ObservableCollection<ListItem> Users { get; set; }

        public SearchUserPage(int userId)
        {
            InitializeComponent();

            this.userId = userId;
            this.SearchUsersService = new SearchUsersService(new Repo.UserRepo());
            this.NotificationsService = new NotificationsService(new NotificationRepo());
            Users = new ObservableCollection<ListItem>();
        }

        private void SearchUsersButton_Click(object sender, RoutedEventArgs e)
        {
            this.UsersListBox.ItemsSource = null;

            string searchKey = this.SearchTextBox.Text;
            List<User> matchedUsers = this.GetAllMatchedUsers(searchKey);

            Users = new ObservableCollection<ListItem>();

            if (matchedUsers.Count == 0)
            {
                Users.Add(new ListItem(-1, "No users found"));
                this.UsersListBox.ItemsSource = Users;
                this.ViewProfileButton.IsEnabled = false;
                return;
            }

            foreach (User user in matchedUsers)
            {
                Users.Add(new ListItem(user.UserId, user.FirstName + " " + user.LastName));
            }

            this.UsersListBox.ItemsSource = Users;
            this.ViewProfileButton.IsEnabled = true;
        }

        private List<User> GetAllMatchedUsers(string searchString)
        {
            return this.SearchUsersService.SearchUsers(searchString, this.userId);
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.Text = string.Empty;
        }

        private void ViewProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ListItem selectedUser = (ListItem)this.UsersListBox.SelectedItem;
            User user = this.SearchUsersService.GetUserById(this.userId);

            Notification profileViewNotification = new Notification(0, selectedUser.Id, user.FirstName + " " + user.LastName + " Viewed your profile!", DateTime.Now, "Profile visited", true);
            this.NotificationsService.AddNotification(profileViewNotification);

            ProfilePage profilePage = new ProfilePage(this.userId, selectedUser.Id);
            profilePage.Show();
            this.Close();
        }
    }
}
