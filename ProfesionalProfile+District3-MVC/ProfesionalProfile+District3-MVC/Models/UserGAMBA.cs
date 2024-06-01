using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class UserGAMBA
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public string Username { get; set; } = string.Empty;
        [Required] public string ProfilePicturePath { get; set; } = string.Empty;

        [NotMapped] public ICollection<Request> SenderRequests { get; } = new List<Request>();
        [NotMapped] public ICollection<Request> ReceiverRequests { get; } = new List<Request>();
    }
}
