using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Block
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public string sender { get; set; }
        [Required] public string receiver { get; set; }
        [Required] public DateTime startingTimeStamp { get; set; }
        [Required] public string reason { get; set; } 
    }
}
