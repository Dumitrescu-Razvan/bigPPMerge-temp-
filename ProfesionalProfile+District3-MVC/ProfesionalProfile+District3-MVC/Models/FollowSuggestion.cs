using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class FollowSuggestion
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public int userId { get; set; }
        [Required] public string username { get; set; }
        [Required] public int numberOfCommonFriends { get; set; }
        [Required] public int numberOfCommonGroups { get; set; }
        [Required] public int numberOfCommonOrganizations { get; set; }
        [Required] public int numberOfCommonTags { get; set; }
        [Required] public string location { get; set; }
    }
}
