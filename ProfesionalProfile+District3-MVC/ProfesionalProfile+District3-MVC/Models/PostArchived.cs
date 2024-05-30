using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class PostArchived
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int post_id { get; set; }
        [Required] public int archive_id { get; set; }
    }
}
