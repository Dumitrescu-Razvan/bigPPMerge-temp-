using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Post
    {
        [Key] public int Id { get; set; }
        [Required] public int Owner_User_Id { get; set; } = 1;
        public string Description { get; set; } = string.Empty;
        public int Commented_Post_Id { get; set; } = 1;
        public int Original_Post_Id { get; set; } = 1;
        public string Media_Path { get; set; } = string.Empty;
        [Required] public short Post_Type { get; set; }
        public int Location_Id { get; set; } = 1;
        [Required] public DateTime Created_Date { get; set; }
    }
}