namespace Server.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int Post_Id { get; set; }
        public int Owner_User_Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
