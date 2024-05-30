using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class FollowedFeedFollowedUsers
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ID { get; set; }
        [Required] public int FollowedFeedID { get; set; }
        [Required] public int FollowedUserID { get; set; }
    }
}
