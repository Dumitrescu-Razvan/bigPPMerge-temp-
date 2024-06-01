using ProfesionalProfile_District3_MVC.Models;


namespace ProfesionalProfile_District3_MVC.Interfaces
{
    public interface ICommentRepository
    {
        Task AddComment(Comment comment);
        bool CommentExists(int id);
        Task DeleteComment(int id);
        Task<Comment> GetComment(int id);
        Task<IEnumerable<Comment>> GetComments();
        Task UpdateComment(Comment comment);
    }
}