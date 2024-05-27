namespace District3_APP_WEB.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }

        public List<User>? GroupMembers { get; set; }
    }
}
