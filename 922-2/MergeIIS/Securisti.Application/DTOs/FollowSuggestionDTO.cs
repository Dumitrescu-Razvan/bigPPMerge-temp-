namespace Server.DTOs
{
    public class FollowSuggestionDTO
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public int numberOfCommonFriends { get; set; }
        public int numberOfCommonGroups { get; set; }
        public int numberOfCommonOrganizations { get; set; }
        public int numberOfCommonTags { get; set; }
        public string location { get; set; }
    }
}