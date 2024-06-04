using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Postaved
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int save_id { get; set; }
        [Required] public int post_id { get; set; }
        [Required] public int user_id { get; set; }
    }
}
