using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Server.Models
{
    public class Request
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey("User")][Required] public int SenderId { get; set; }
        [NotMapped] public RetardedUser SenderUser { get; set; } = null!;
        [ForeignKey("User")][Required] public int ReceiverId { get; set; }
        [NotMapped] public RetardedUser ReceiverUser { get; set; } = null!;
         
    }
}
