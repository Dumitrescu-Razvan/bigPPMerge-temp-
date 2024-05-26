using District3API.domain;
using District3API.DataBaseContext;
using District3API.RepoInterfaces;

namespace District3API.Repos
{
    public class UserRepository : IRepoInterface<AutisticUser>
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(AutisticUser item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.User.Find(id);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
            }
        }

        public ICollection<AutisticUser> GetAll()
        {
            return _context.User.ToList();
        }

        public AutisticUser GetById(int id)
        {
            return _context.User.Find(id);
        }

        public void Update(AutisticUser item)
        {
            _context.User.Update(item);
            _context.SaveChanges();
        }
    }
}