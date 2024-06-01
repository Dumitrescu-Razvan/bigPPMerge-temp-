using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;

namespace ProfesionalProfile_District3_MVC.Repositories
{
    public class HighlightRepository : IRepoInterface<Highlight>
    {
        private readonly ApplicationDbContext _context;
        public HighlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Highlight item)
        {
            _context.Highlight.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var highlight = _context.Highlight.Find(id);
            if (highlight != null)
            {
                _context.Highlight.Remove(highlight);
                _context.SaveChanges();
            }
        }

        public ICollection<Highlight> GetAll()
        {
            return _context.Highlight.ToList();
        }

        public Highlight GetById(int id)
        {
            return _context.Highlight.Find(id);
        }

        public void Update(Highlight item)
        {
            _context.Highlight.Update(item);
            _context.SaveChanges();
        }
    }
}