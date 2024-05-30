using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Follow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public string sender { get; set; }
        [Required] public string receiver { get; set; }
        [Required] public bool isCloseFriend { get; set; }
        [Required] public DateTime expirationTimeStamp { get; set; }
        [Required] public string description { get; set; }
    }
}
