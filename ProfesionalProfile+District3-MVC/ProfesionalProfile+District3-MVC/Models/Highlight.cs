using System.Text.Json.Serialization;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Highlight
    {
        public int HighlightId { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public List<int>? PostIds { get; set; }
        public string? Name { get; set; }
        public string? CoverFilePath { get; set; }
    }
}
