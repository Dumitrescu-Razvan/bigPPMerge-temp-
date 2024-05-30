using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class ControversialFeed
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ID { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
        [Required] public int ReactionThreshold { get; set; }
        [Required] public int MinimumReactionCount { get; set; }
        [Required] public int MinimumCommentCount { get; set; }
    }
}
