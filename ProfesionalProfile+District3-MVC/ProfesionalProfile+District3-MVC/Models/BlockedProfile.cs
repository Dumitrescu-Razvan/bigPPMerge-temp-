using System.Text.Json.Serialization;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class BlockedProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public DateTime BlockDate { get; set; }
    }
}
