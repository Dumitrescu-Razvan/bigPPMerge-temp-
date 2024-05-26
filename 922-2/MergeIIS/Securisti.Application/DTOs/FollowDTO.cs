namespace Server.DTOs
{
    public class FollowDTO
    {
        public int Id { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public bool isCloseFriend { get; set; }
        public DateTime expirationTimeStamp { get; set; }
        public string description { get; set; }
    }
}
