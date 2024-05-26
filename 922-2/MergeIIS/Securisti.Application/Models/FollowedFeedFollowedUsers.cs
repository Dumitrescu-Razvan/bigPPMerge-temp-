using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class FollowedFeedFollowedUsers
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ID { get; set; }
        [Required] public int FollowedFeedID { get; set; }
        [Required] public int FollowedUserID { get; set; }
    }
}
