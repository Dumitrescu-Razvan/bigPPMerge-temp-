using System.Text.Json.Serialization;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Account
    {
            public int Id { get; set; }
            public string? CardNumber { get; set; }
            public string? HolderName { get; set; }
            public string? ExpirationDate { get; set; }
            public string? Cvv { get; set; }
            public int UserId { get; set; }
            [JsonIgnore]
            public User? User { get; set; }
        
    }
}
