namespace Server.DTOs
{
    public class PostDTO
    {
        public int Post_Id { get; set; } 
        public int Owner_User_Id { get; set; } 
        public string Description { get; set; } = string.Empty;
        public int Commented_Post_Id { get; set; } 
        public int Original_Post_Id { get; set; } 
        public string Media_Path { get; set; } = string.Empty;
        public short Post_Type { get; set; }
        public int Location_Id { get; set; }
        public DateTime Created_Date { get; set; }
    }
}