using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace Server.Models
{
    public class Comment
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public int Post_Id { get; set; }
        [Required] public int Owner_User_Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}