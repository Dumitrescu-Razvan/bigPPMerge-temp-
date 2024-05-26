
namespace District3API.domain
{
    public class Group 
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }

        public List<AutisticUser>? GroupMembers { get; set; }
    }
}
