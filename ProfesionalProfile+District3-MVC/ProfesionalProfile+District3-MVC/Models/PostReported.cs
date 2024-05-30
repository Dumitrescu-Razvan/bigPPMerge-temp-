using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class PostReported
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Report_Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //post_id is foreign key
        [Required] public int Post_Id { get; set; }
        [Required] public int Reporter_Id { get; set; }
    }
}
