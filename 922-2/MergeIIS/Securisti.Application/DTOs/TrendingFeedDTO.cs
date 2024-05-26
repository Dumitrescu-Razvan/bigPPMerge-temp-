namespace Server.DTOs
{
    public class TrendingFeedDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ReactionThreshold { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }
    }
}