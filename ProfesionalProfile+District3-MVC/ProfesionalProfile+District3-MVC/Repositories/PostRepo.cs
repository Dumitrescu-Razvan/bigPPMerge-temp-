using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class PostRepository : IRepoInterface<Post>
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Post item)
        {
            _context.Post.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = _context.Post.Find(id);
            if (post != null)
            {
                _context.Post.Remove(post);
                _context.SaveChanges();
            }
        }

        public ICollection<Post> GetAll()
        {
            return _context.Post.ToList();
        }

        public Post GetById(int id)
        {
            return _context.Post.Find(id);
        }

        public void Update(Post item)
        {
            _context.Post.Update(item);
            _context.SaveChanges();
        }
    }
}