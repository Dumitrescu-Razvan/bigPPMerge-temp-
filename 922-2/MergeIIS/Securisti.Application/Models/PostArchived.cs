using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class PostArchived
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int post_id { get; set; }
        [Required] public int archive_id { get; set; }
    }

}
