using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UBB_SE_2024_Gaborment.Server.Models
{
    public class TrendingFeed
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ID { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
        [Required] public int ReactionThreshold { get; set; }
        [Required] public int LikeCount { get; set; }
        [Required] public int ViewCount { get; set; }
        [Required] public int CommentCount { get; set; }
    }
}