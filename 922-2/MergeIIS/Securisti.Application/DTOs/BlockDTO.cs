namespace Server.DTOs
{
    public class BlockDTO
    {
        public int Id { get; set; }
        public string sender {  get; set; }
        public string receiver { get; set; }
        public DateTime startingTimeStamp {  get; set; }
        public string reason { get; set; }
    }
}
