namespace Server.DTOs
{
    public class ControversialFeedDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ReactionThreshold { get; set; }
        public int MinimumReactionCount { get; set; }
        public int MinimumCommentCount { get; set; }
    }
}