using System.Text.Json.Serialization;

namespace District3_APP_WEB.Models
{
    public class CloseFriendProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public DateTime CloseFriendedDate { get; set; }
    }
}
