
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Request
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("User")][Required] public int SenderId { get; set; }
        [NotMapped] public User? SenderUser { get; set; } = null!;
        [ForeignKey("User")][Required] public int ReceiverId { get; set; }
        [NotMapped] public User? ReceiverUser { get; set; } = null!;
    }
}
