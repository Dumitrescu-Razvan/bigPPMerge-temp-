using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using Microsoft.Win32;

namespace ProfessionalProfile.Business_card_page
{
    public partial class BusinessCardPage : Window
    {
        private UserRepo usersRepo = new UserRepo();
        private SkillRepo skillRepo = new SkillRepo();
        private BusinessCardRepo businessCardRepo = new BusinessCardRepo();

        public BusinessCardPage(int userId)
        {
            InitializeComponent();

            BussinesCard businessCard = businessCardRepo.GetByUserId(userId);
            User user = usersRepo.GetById(userId);
            List<Skill> skills = skillRepo.GetByUserId(userId);

            if (businessCard == null)
            {
                BussinesCard newCard = new BussinesCard(0, user.Summary, "htpps://business_card_" + user.FirstName, user.UserId, skills);
                businessCardRepo.Add(newCard);
            }
            businessCard = businessCardRepo.GetByUserId(userId);

            List<string> cardSkills = new List<string>();

            foreach (Skill skill in skills)
            {
                if (!cardSkills.Contains(skill.Name.ToLower()))
                {
                    cardSkills.Add(skill.Name);
                }
            }

            FullName = user.FirstName + " " + user.LastName;
            PhoneNumber = user.Phone;

            Email = user.Email;
            WebsiteURL = businessCard.UniqueUrl;
            KeySkills = string.Join(",",  cardSkills);
            Description = businessCard.Summary;

            DataContext = this;
        }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string WebsiteURL { get; set; }
        public string KeySkills { get; set; }
        public string Description { get; set; }
        public string Achievement { get; set; }

        // Commands for button actions
        public ICommand GenerateQRCodeCommand { get; }
        public ICommand GoToProfileCommand { get; }
        public ICommand DownloadCardCommand { get; }

        // Methods for command actions
        private void GenerateQRCode(object parameter)
        {
            // Code to generate QR code
        }

        private void GoToProfile(object parameter)
        {
            // Code to navigate to profile page
        }

        private void DownloadCard(object parameter)
        {
            // Code to download business card
        }

        // Implementation of INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DownloadCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)this.ActualWidth, (int)this.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(this);

                // Create a BitmapEncoder to save the captured content as an image
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

                // Allow user to choose where to save the file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Save Business Card Image";
                saveFileDialog.FileName = "business_card.png"; // Default file name
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Save the image to the selected file
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        encoder.Save(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the file-saving process
                Console.WriteLine("An error occurred while saving the image: " + ex.Message);
            }
        }
    }
}


