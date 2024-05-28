using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class User
    {
        // <------------------------------------ District3 ------------------------------------>
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? ConfirmationPassword { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? FollowingCount { get; set; }
        public int? FollowersCount { get; set; }
        [JsonIgnore]
        public TimeSpan? UserSession { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        // From ProfessionalProfile

        public string? Summary { get; set; }
        public bool? DarkTheme { get; set; }
        public string? Phone { get; set; }
        public string? WebsiteURL { get; set; }

        

        // <------------------------------------ ProfessionalProfile ------------------------------------>
        /**public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string summary { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool darkTheme { get; set; }
        public string address { get; set; }
        public string websiteURL { get; set; }
        public string picture { get; set; } **/

        // Navigation property for one-to-one relationship
        [JsonIgnore]
        public Privacy? Privacy { get; set; }
        [JsonIgnore]
        public ICollection<Notification>? Notifications { get; set; }
        [JsonIgnore]
        public AssessmentResult? AssessmentResult { get; set; }
        [JsonIgnore]
        public Project? Project { get; set; }
        [JsonIgnore]
        public Volunteering? Volunteering { get; set; }
        [JsonIgnore]
        public WorkExperience? WorkExperience { get; set; }
    }
}
