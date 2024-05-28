using System.Text.Json.Serialization;

namespace District3_APP_WEB.Models
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
