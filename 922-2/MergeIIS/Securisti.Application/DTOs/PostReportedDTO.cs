namespace Server.DTOs
{
    public class PostReportedDTO
    {
        public int Report_Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Post_Id { get; set; }
        public int Reporter_Id { get; set; }
    }
}
