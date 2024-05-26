using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class PostSaved
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int save_id { get; set; }
        [Required] public int post_id { get; set; }
        [Required] public int user_id { get; set; }
    }
}
